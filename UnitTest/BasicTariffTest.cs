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

    [Fact]
    public void Annual_Consumption_3500()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 3500);

        annualCost.Should().Be(830);
    }

    [Fact]
    public void Annual_Consumption_4500()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 4500);

        annualCost.Should().Be(1050);
    }

    [Fact]
    public void Annual_Consumption_6000()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 6000);

        annualCost.Should().Be(1380);
    }

    [Fact]
    public void Annual_Consumption_Zero_CostPerKWh()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 0m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 2000);

        annualCost.Should().Be(60);
    }

    [Fact]
    public void Annual_Consumption_Negative_Value()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, -1);

        annualCost.Should().Be(0);
    }
}
