using Application.Products.Commands;
using Application.Products.Queries;
using Domain.ProductAggregate.Tariffs;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductQueryUseCase, ProductQueryUseCase>();

        services.AddScoped<IProductCommandUseCase, ProductCommandUseCase>();

        services.AddScoped<ITariffFactory, TariffFactory>();

        return services;
    }
}
