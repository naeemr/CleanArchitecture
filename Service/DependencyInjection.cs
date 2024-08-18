using Microsoft.EntityFrameworkCore;
using Service.Application.Common.Interfaces;
using Service.Application.Products;
using Service.Domain.ProviderAggregate.Tariffs;
using Service.Infrastructure.Persistence;
using Service.Services;

namespace Service;

public static class DependencyInjection
{
	public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IProductUseCase, ProductUseCase>();

		services.AddScoped<ITariffFactory, TariffFactory>();

		services.AddDbContext<ApplicationDbContext>(options =>
			  options.UseInMemoryDatabase(databaseName: "TariffsDB"));

		//services.AddDbContext<ApplicationDbContext>(options =>
		//		 options.UseSqlServer(
		//			 configuration.GetConnectionString("TariffsDB")));

		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddSingleton<ICurrentUserService, CurrentUserService>();

		return services;
	}
}
