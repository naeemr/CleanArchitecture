namespace Domain.ProductAggregate.Tariffs;

public sealed class BasicTariff : ITariff
{
    public decimal CalculateAnnualCost(Product product, int consumption)
    {
        if (consumption <= 0)
        {
            return default;
        }

        var annualBaseCost = product.BaseCost * 12;

        var annualCost = annualBaseCost + (consumption * (product.CostPerKWh / 100));

        return annualCost;
    }
}
