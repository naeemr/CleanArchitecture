using Application.Common.Model;
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
    public async Task Products_MultipleConsumptions_ReturnsProductsWithDifferentTariffs(int consumption, decimal output)
    {
        //Setup
        var requestBuilder = NewRequest
           .AddRoute($"product/{consumption}");

        var response = await requestBuilder.Get<ApiResponse<List<GetProducts>>>();

        response.Should().NotBeNull();

        response.Result.Should().NotBeNull();

        var product = response.Result.FirstOrDefault();

        product.Should().NotBeNull();

        product.AnnualCost.Should().Be(output);
    }

    [Fact]
    public async Task Products_NegativeValue_ReturnsZero()
    {
        int consumption = -1;

        var requestBuilder = NewRequest
          .AddRoute($"product/{consumption}");

        var response = await requestBuilder.Get<ApiResponse<List<GetProducts>>>();

        response.Should().NotBeNull();

        response.Result.Should().NotBeNull();

        var product = response.Result.FirstOrDefault();

        product.Should().NotBeNull();

        product.AnnualCost.Should().Be(0);
    }
}
