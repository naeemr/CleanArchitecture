using FluentAssertions;
using Service.Domain.ProviderAggregate;
using Service.Domain.ProviderAggregate.Tariffs;
using Xunit;
using static Service.Domain.ProviderAggregate.Product;

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
		// Arrange
		Product product = new("GreenPower", "Fixed Saver Plan", "Packaged tariff", TariffType.Premium, 4000, 800m, 30m, "Annual");

		// Act
		var tariff = _tariffFactory.Create(product.Type);

		var annualCost = tariff.CalculateAnnualCost(product, 3500);

		// Assert
		annualCost.Should().Be(0);
	}
}
