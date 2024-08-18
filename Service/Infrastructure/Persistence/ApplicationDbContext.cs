using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Service.Application.Common.Interfaces;
using Service.Domain;
using Service.Domain.ProviderAggregate;
using System.Reflection;
using System.Threading;

namespace Service.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
	private readonly ICurrentUserService _currentUserService;

	public ApplicationDbContext(ICurrentUserService currentUserService,
		DbContextOptions options) : base(options)
	{
		_currentUserService = currentUserService;
	}

	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public override int SaveChanges()
	{
		try
		{
			SetAuditFields(ChangeTracker.Entries<IBaseEntity>());

			var result = base.SaveChanges();

			return result;
		}
		catch (DbUpdateConcurrencyException)
		{
			throw;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		try
		{
			SetAuditFields(ChangeTracker.Entries<IBaseEntity>());

			var result = await base.SaveChangesAsync(cancellationToken);

			return result;
		}
		catch (DbUpdateConcurrencyException)
		{
			throw;
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void SetAuditFields(IEnumerable<EntityEntry<IBaseEntity>> entries)
	{
		try
		{
			foreach (var entry in entries.ToList())
			{
				switch (entry.State)
				{
					case EntityState.Added:

						entry.Entity.SetAddedFields(_currentUserService.UserId);
						break;

					case EntityState.Modified:

						entry.Property(x => x.CreatedBy).IsModified = false;
						entry.Property(x => x.CreatedOn).IsModified = false;

						entry.Entity.SetUpdatedFields(_currentUserService.UserId);
						break;
				}
				//var validationContext = new ValidationContext(entry);
				//Validator.ValidateObject(entry, validationContext);
			}
		}
		catch (Exception)
		{
			throw;
		}
	}
}
