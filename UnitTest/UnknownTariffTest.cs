using Domain.Entities;
using Domain.Tariffs;
using FluentAssertions;
using Xunit;
using static Domain.Entities.Product;

namespace UnitTest;

public class UnknownTariffTest
{
    private readonly ITariffFactory _tariffFactory;

    public UnknownTariffTest()
    {
        _tariffFactory = new TariffFactory();
    }

    [Fact]
    public void CalculateAnnualCost_CostPerKWh30mAndConsumption3500_0()
    {
        Product product = new("Packaged tariff", TariffType.Premium, 4000, 800m, 30m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 3500);

        annualCost.Should().Be(0);
    }
}
