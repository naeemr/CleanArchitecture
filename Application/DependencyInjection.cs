namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGetProductsHandler, GetProductsHandler>();

        services.AddScoped<ITariffFactory, TariffFactory>();

        return services;
    }
}
