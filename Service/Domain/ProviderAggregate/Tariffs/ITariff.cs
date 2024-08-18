namespace Service.Domain.ProviderAggregate.Tariffs;

public interface ITariff
{
	decimal CalculateAnnualCost(Product product, int consumption);
}
