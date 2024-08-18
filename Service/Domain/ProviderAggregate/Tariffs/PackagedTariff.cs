namespace Service.Domain.ProviderAggregate.Tariffs;

public sealed class PackagedTariff : ITariff
{
	public decimal CalculateAnnualCost(Product product, int consumption)
	{
		if (consumption <= 0)
		{
			return default;
		}

		var annualCost = product.BaseCost;

		if (consumption > product.AllowedConsumption)
		{
			var additionalConsumption = consumption - product.AllowedConsumption;

			annualCost += (additionalConsumption * (product.CostPerKWh / 100));
		}

		return annualCost;
	}
}
