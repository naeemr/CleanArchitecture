using Service.Domain.ProviderAggregate;
using Service.Infrastructure.Persistence;
using static Service.Domain.ProviderAggregate.Product;

namespace Service.Infrastructure;

public static class DataGenerator
{
	private static bool isDataLoaded = false;

	public static void CreateData(this ApplicationDbContext context)
	{
		context.AddRange(
				new Product("GreenPower", "Eco Saver Plan", "basic electricity tariff", TariffType.Basic, 0, 5m, 22m,"Monthly"),
				new Product("GreenPower", "Fixed Saver Plan", "Packaged tariff", TariffType.Packaged, 4000, 800m, 30m, "Annual")
			);

		context.SaveChanges();

		isDataLoaded = true;
	}

	public static bool CheckDataLoaded(this ApplicationDbContext context)
	{
		return isDataLoaded;
	}
}
