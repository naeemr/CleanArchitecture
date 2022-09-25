using static Domain.ProductAggregate.Product;

namespace Domain.ProductAggregate.Tariffs;

public interface ITariffFactory
{
    ITariff Create(TariffType type);
}

public class TariffFactory : ITariffFactory
{
    public ITariff Create(TariffType type)
    {
        try
        {
            var tariff = (ITariff)Activator.CreateInstance(
                        Type.GetType($"Domain.ProductAggregate.Tariffs.{type}Tariff"));

            return tariff;
        }
        catch (Exception)
        {
            return new UnknownTariff();
        }
    }
}
