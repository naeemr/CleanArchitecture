using Application.Products.Commands;
using Application.Products.Queries;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Commands;
using Infrastructure.Persistence.Queries;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase(databaseName: "TariffsDB"));

        //services.AddDbContext<ApplicationDbContext>(options =>
        //         options.UseSqlServer(
        //             configuration.GetConnectionString("TariffsDB")));

        services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();

        return services;
    }
}
