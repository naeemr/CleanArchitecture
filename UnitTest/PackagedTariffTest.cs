using Domain.Entities;
using Domain.Tariffs;
using FluentAssertions;
using Xunit;
using static Domain.Entities.Product;

namespace UnitTest
{
    public class PackagedTariffTest
    {
        private readonly ITariffFactory _tariffFactory;

        public PackagedTariffTest()
        {
            _tariffFactory = new TariffFactory();
        }

        [Fact]
        public void CalculateAnnualCost_CostPerKWh30mAndConsumption3500_800()
        {
            Product product = new("Packaged tariff", TariffType.Packaged, 4000, 800m, 30m);

            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, 3500);

            annualCost.Should().Be(800);
        }

        [Fact]
        public void CalculateAnnualCost_CostPerKWh30mAndConsumption4500_950()
        {
            Product product = new("Packaged tariff", TariffType.Packaged, 4000, 800m, 30m);

            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, 4500);

            annualCost.Should().Be(950);
        }

        [Fact]
        public void CalculateAnnualCost_CostPerKWh30mAndConsumption6000_1400()
        {
            Product product = new("Packaged tariff", TariffType.Packaged, 4000, 800m, 30m);

            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, 6000);

            annualCost.Should().Be(1400);
        }

        [Fact]
        public void CalculateAnnualCost_CostPerKWh0mAndConsumption5000_800()
        {
            Product product = new("Packaged tariff", TariffType.Packaged, 4000, 800m, 0m);

            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, 5000);

            annualCost.Should().Be(800);
        }

        [Fact]
        public void CalculateAnnualCost_CostPerKWh30mAndConsumptionMinusOne_0()
        {
            Product product = new("Packaged tariff", TariffType.Packaged, 4000, 800m, 30m);

            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, -1);

            annualCost.Should().Be(0);
        }
    }
}
