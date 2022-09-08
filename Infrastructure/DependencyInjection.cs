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

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
