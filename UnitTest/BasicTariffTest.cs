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
    public void CalculateAnnualCost_CostPerKWh22mAndConsumption3500_830()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 3500);

        annualCost.Should().Be(830);
    }

    [Fact]
    public void CalculateAnnualCost_CostPerKWh22mAndConsumption4500_1050()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 4500);

        annualCost.Should().Be(1050);
    }

    [Fact]
    public void CalculateAnnualCost_CostPerKWh22mAndConsumption6000_1380()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 6000);

        annualCost.Should().Be(1380);
    }

    [Fact]
    public void CalculateAnnualCost_CostPerKWh0mAndConsumption2000_60()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 0m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, 2000);

        annualCost.Should().Be(60);
    }

    [Fact]
    public void CalculateAnnualCost_CostPerKWh22mAndConsumptionMinusOne_0()
    {
        Product product = new("basic electricity tariff", TariffType.Basic, 0, 5m, 22m);

        var tariff = _tariffFactory.Create(product.Type);

        var annualCost = tariff.CalculateAnnualCost(product, -1);

        annualCost.Should().Be(0);
    }
}
