namespace Domain.Tariffs;

public class UnknownTariff : ITariff
{
    public decimal CalculateAnnualCost(Product product, int consumption)
    {
        return 0;
    }
}
