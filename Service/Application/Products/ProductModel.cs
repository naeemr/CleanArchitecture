namespace Service.Application.Products;

public class ProductModel
{
	public string TariffName { get; private set; }
	public decimal TotalAnnualCost { get; private set; }
	public string ProviderName { get; private set; }
	public string ProductName { get; private set; }
	public int AllowedConsumption { get; private set; }
	public decimal BaseCost { get; private set; }
	public decimal CostPeKWh { get; private set; }
	public string BaseCostPeriod { get; private set; }

	public ProductModel(string provider,
		string productName,
		string tariffName,
		decimal baseCost,
		decimal costPerKwh,
		decimal annualCost,
		int allowedConsumption,
		string baseCostPeriod)
	{
		ProviderName = provider;
		ProductName = productName;
		TariffName = tariffName;
		TotalAnnualCost = annualCost;
		BaseCost = baseCost;
		CostPeKWh = costPerKwh;
		AllowedConsumption = allowedConsumption;
		BaseCostPeriod = baseCostPeriod;
	}
}
