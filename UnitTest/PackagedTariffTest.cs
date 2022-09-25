using Domain.ProductAggregate;
using Domain.ProductAggregate.Tariffs;
using FluentAssertions;
using Xunit;
using static Domain.ProductAggregate.Product;

namespace UnitTest;

public class PackagedTariffTest
{
    private readonly ITariffFactory _tariffFactory;

    public PackagedTariffTest()
    {
        _tariffFactory = new TariffFactory();
    }

    [Theory]
    [InlineData(3500, 30, 800)]
    [InlineData(4500, 30, 950)]
    [InlineData(6000, 30, 1400)]
    [InlineData(5000, 0, 800)]
    [InlineData(-1, 30, 0)]
    public void CalculateAnnualCost_MultipleConsumptions_ReturnsAnnualCosts(int consumption, decimal costPerKWh, decimal output)
    {
        Product product = new("Packaged tariff", TariffType.Packaged, 4000, 800m, costPerKWh);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, consumption);

        annualCost.Should().Be(output);
    }
}
