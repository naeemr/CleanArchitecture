using FluentAssertions;
using Service.Domain.ProviderAggregate;
using Service.Domain.ProviderAggregate.Tariffs;
using Xunit;
using static Service.Domain.ProviderAggregate.Product;

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
	[InlineData(0, 30, 0)]
	[InlineData(-1, 30, 0)]
	[InlineData(5000, 0, 800)]
	public void CalculateAnnualCost_MultipleConsumptions_ReturnsAnnualCosts(int consumption, decimal costPerKWh, decimal output)
	{
		// Arrange
		Product product = new("GreenPower", "Fixed Saver Plan", "Packaged tariff", TariffType.Packaged, 4000, 800m, costPerKWh, "Annual");

		// Act
		var tariff = _tariffFactory.Create(product.Type);

		var annualCost = tariff.CalculateAnnualCost(product, consumption);

		// Assert
		annualCost.Should().Be(output);
	}
}
