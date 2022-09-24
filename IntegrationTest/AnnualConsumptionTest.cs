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
 
    [Theory]
    [InlineData(3500, 800)]
    [InlineData(4500, 950)]
    [InlineData(6000, 1380)]
    public async Task Annual_Consumption_3500(int consumption, decimal output)
    {
        //Setup
        var requestBuilder = NewRequest
           .AddRoute($"product/{consumption}");

        var products = await requestBuilder.Get<IEnumerable<ProductDTO>>();

        products.Should().NotBeNull();

        var product = products.FirstOrDefault();

        product.Should().NotBeNull();

        product.AnnualCost.Should().Be(output);
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
