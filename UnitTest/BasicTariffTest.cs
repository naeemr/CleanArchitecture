using Domain.Entities;
using Domain.Tariffs;
using FluentAssertions;
using Xunit;
using static Domain.Entities.Product;

namespace UnitTest;

public class BasicTariffTest
{
    private readonly ITariffFactory _tariffFactory;

    public BasicTariffTest()
    {
        _tariffFactory = new TariffFactory();
    }

    [Theory]
    [InlineData(3500, 22, 830)]
    [InlineData(4500, 22, 1050)]
    [InlineData(6000, 22, 1380)]
    [InlineData(2000, 0, 60)]
    [InlineData(-1, 22, 0)]
    public void CalculateAnnualCost_MultipleConsumptions_ReturnsAnnualCosts(int consumption, decimal costPerKWh, decimal output)
    {
        Product product = new Product("basic electricity tariff", TariffType.Basic, 0, 5m, costPerKWh);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, consumption);

        annualCost.Should().Be(output);
    }
}
