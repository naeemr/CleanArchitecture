using FluentAssertions;
using IntegrationTest.Infrastructure;
using Service.Application.Common.Model;
using Service.Application.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace IntegrationTest;

public class AnnualConsumptionTest : IntegrationTestBase
{
	public AnnualConsumptionTest(IntegrationTestFixture integrationTestFixture)
		: base(integrationTestFixture)
	{

	}

	private readonly JsonSerializerSettings _defaultSettings
		= new()
		{
			ContractResolver = new PrivateResolver(),
			NullValueHandling = NullValueHandling.Ignore
		};

	[Theory]
	[InlineData(3500, 800)]
	[InlineData(4500, 950)]
	[InlineData(6000, 1380)]
	public async Task GetProducts_MultipleConsumptions_ReturnsProductsTariff(int consumption, decimal output)
	{
		// Arrange
		var requestBuilder = NewRequest
		   .AddRoute($"product/{consumption}");

		// Act
		var response = await requestBuilder.Get(false);

		var content = await response.Content.ReadAsStringAsync();

		ApiResponse<List<ProductModel>> apiResponse = 
			JsonConvert.DeserializeObject<ApiResponse<List<ProductModel>>>(content, _defaultSettings);

		// Assert
		apiResponse.Result.Should().NotBeNull();

		apiResponse.Result.Should().NotBeNull();

		var product = apiResponse.Result.FirstOrDefault();

		product.Should().NotBeNull();

		product.TotalAnnualCost.Should().Be(output);
	}

	[Fact]
	public async Task GetProducts_NegativeValue_ReturnsProductsTariff()
	{
		// Arrange
		int consumption = -1;

		var requestBuilder = NewRequest
		  .AddRoute($"product/{consumption}");

		// Act
		var response = await requestBuilder.Get(false);

		var content = await response.Content.ReadAsStringAsync();

		ApiResponse<List<ProductModel>> apiResponse = 
			JsonConvert.DeserializeObject<ApiResponse<List<ProductModel>>>(content, _defaultSettings);

		// Assert
		response.Should().NotBeNull();

		apiResponse.Result.Should().BeNull();
	}

	public class PrivateResolver : DefaultContractResolver
	{
		protected override JsonProperty CreateProperty(
			MemberInfo member,
			MemberSerialization memberSerialization)
		{
			var prop = base.CreateProperty(member, memberSerialization);
			if (!prop.Writable)
			{
				var property = member as PropertyInfo;
				var hasPrivateSetter = property?.GetSetMethod(true) != null;
				prop.Writable = hasPrivateSetter;
			}
			return prop;
		}
	}
}
