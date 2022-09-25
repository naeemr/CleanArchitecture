using Domain.ProductAggregate;
using Infrastructure.Persistence;
using static Domain.ProductAggregate.Product;

namespace Infrastructure;

public static class DataGenerator
{
    private static bool isDataLoaded = false;

    public static void CreateData(this ApplicationDbContext context)
    {
        context.AddRange(
                new Product("basic electricity tariff", TariffType.Basic, 0, 5m, 22m),
                new Product("Packaged tariff", TariffType.Packaged, 4000, 800m, 30m)
            );

        context.SaveChanges();

        isDataLoaded = true;
    }

    public static bool CheckDataLoaded(this ApplicationDbContext context)
    {
        return isDataLoaded;
    }
}
