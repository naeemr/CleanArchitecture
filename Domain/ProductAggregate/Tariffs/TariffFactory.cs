using static Domain.ProductAggregate.Product;

namespace Domain.ProductAggregate.Tariffs;

public interface ITariffFactory
{
    ITariff Create(TariffType type);
}

public class TariffFactory : ITariffFactory
{
    private readonly static Dictionary<string, ITariff> tariffs = new();

    public ITariff Create(TariffType type)
    {
        try
        {
            ITariff tariff;

            var fullType = $"Domain.ProductAggregate.Tariffs.{type}Tariff";

            if (tariffs.Any())
            {
                tariff = tariffs.Where(s => s.Key == fullType)
                    .Select(s => s.Value).FirstOrDefault();

                if (tariff != null)
                {
                    return tariff;
                }
            }

            tariff = (ITariff)Activator.CreateInstance(
                        Type.GetType(fullType));

            tariffs.Add(fullType, tariff);

            return tariff;
        }
        catch (Exception)
        {
            return new UnknownTariff();
        }
    }
}
