namespace Domain.ProductAggregate.Tariffs;

public interface ITariff
{
    decimal CalculateAnnualCost(Product product, int consumption);
}
