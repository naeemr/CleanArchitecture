using FluentAssertions;
using Service.Domain.ProviderAggregate;
using Service.Domain.ProviderAggregate.Tariffs;
using Xunit;
using static Service.Domain.ProviderAggregate.Product;

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
	[InlineData(0, 22, 0)]
	[InlineData(-1, 22, 0)]
	[InlineData(2000, 0, 60)]
	public void CalculateAnnualCost_MultipleConsumptions_ReturnsAnnualCosts(int consumption, decimal costPerKWh, decimal output)
	{
		// Arrange
		Product product = new("GreenPower", "Eco Saver Plan", "basic electricity tariff", TariffType.Basic, 0, 5m, costPerKWh, "Monthly");

		// Act
		var tariff = _tariffFactory.Create(product.Type);

		var annualCost = tariff.CalculateAnnualCost(product, consumption);

		// Assert
		annualCost.Should().Be(output);
	}
}
