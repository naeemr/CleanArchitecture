namespace Domain.Tariffs;

public interface ITariff
{
    decimal CalculateAnnualCost(Product product, int consumption);
}
