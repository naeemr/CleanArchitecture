namespace Service.Domain.ProviderAggregate;

public class Product : BaseEntity, IAggregateRoot
{
	public enum TariffType
	{
		Basic,
		Packaged,
		Premium
	}

	public string Provider { get; private set; }
	public string ProductName { get; private set; }
	public string TariffName { get; private set; }
	public TariffType Type { get; private set; }
	public int AllowedConsumption { get; private set; }
	public decimal BaseCost { get; private set; }
	public decimal CostPerKWh { get; private set; }
	public string BaseCostPeriod { get; private set; }

	private Product() { }

	public Product(
		string providerName,
		string productName,
		string tariffName,
		TariffType tariffType,
		int allowedConsumption,
		decimal baseCost,
		decimal costPerKWh,
		string baseCostPeriod)
	{
		Provider = providerName;
		ProductName = productName;
		TariffName = tariffName;
		Type = tariffType;
		AllowedConsumption = allowedConsumption;
		BaseCost = baseCost;
		CostPerKWh = costPerKWh;
		BaseCostPeriod = baseCostPeriod;
	}
}
