using Application.Products.Queries;
using FluentAssertions;
using IntegrationTest.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest;

public class AnnualConsumptionTest : IntegrationTestBase
{
    public AnnualConsumptionTest(IntegrationTestFixture integrationTestFixture)
        : base(integrationTestFixture)
    {

    }

    [Fact]
    public async Task Annual_Consumption_3500()
    {
        //Setup
        int consumption = 3500;

        var requestBuilder = NewRequest
           .AddRoute($"product/{consumption}");

        var products = await requestBuilder.Get<IEnumerable<ProductDTO>>();

        products.Should().NotBeNull();

        var product = products.FirstOrDefault();

        product.Should().NotBeNull();

        product.AnnualCost.Should().Be(800);
    }

    [Fact]
    public async Task Annual_Consumption_4500()
    {
        //Setup        
        int consumption = 4500;

        var requestBuilder = NewRequest
          .AddRoute($"product/{consumption}");

        var products = await requestBuilder.Get<IEnumerable<ProductDTO>>();

        products.Should().NotBeNull();

        var product = products.FirstOrDefault();

        product.Should().NotBeNull();

        product.AnnualCost.Should().Be(950);
    }

    [Fact]
    public async Task Annual_Consumption_6000()
    {
        int consumption = 6000;

        var requestBuilder = NewRequest
          .AddRoute($"product/{consumption}");

        var products = await requestBuilder.Get<IEnumerable<ProductDTO>>();

        products.Should().NotBeNull();

        var product = products.FirstOrDefault();

        product.Should().NotBeNull();

        product.AnnualCost.Should().Be(1380);

    }

    [Fact]
    public async Task Annual_Consumption_Negative_Value()
    {
        int consumption = -1;

        var requestBuilder = NewRequest
          .AddRoute($"product/{consumption}");

        var products = await requestBuilder.Get<IEnumerable<ProductDTO>>();

        products.Should().NotBeNull();

        products.Should().HaveCount(0);
    }
}
