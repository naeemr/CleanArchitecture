using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Domain.ProviderAggregate;
using static Service.Domain.ProviderAggregate.Product;

namespace Service.Infrastructure.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(p => new { p.Id });

		builder.ToTable("Product");

		builder.Property(s => s.ProductName)
			.HasMaxLength(100);

		builder.Property(p => p.Type)
			.HasMaxLength(20)
			.HasConversion(
			v => v.ToString(),
			v => (TariffType)Enum.Parse(typeof(TariffType), v));

		builder.Property(p => p.BaseCost)
			.HasColumnType("decimal(7,2)");

		builder.Property(p => p.CostPerKWh)
			.HasColumnType("decimal(7,2)");
	}
}
