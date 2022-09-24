namespace Domain.Entities;

public class Product : BaseEntity, IAggregateRoot
{
    public enum TariffType
    {
        Basic,
        Packaged,
        Premium
    }

    public string Name { get; private set; }
    public TariffType Type { get; private set; }
    public int AllowedConsumption { get; private set; }
    public decimal BaseCost { get; private set; }
    public decimal CostPerKWh { get; private set; }

    private Product()
    {

    }

    public Product(string name,
        TariffType tariffType,
        int allowedConsumption,
        decimal baseCost,
        decimal costPerKWh)
    {
        Name = name;
        Type = tariffType;
        AllowedConsumption = allowedConsumption;
        BaseCost = baseCost;
        CostPerKWh = costPerKWh;
    }
}
