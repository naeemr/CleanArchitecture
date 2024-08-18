using Service.Infrastructure;
using Service.Infrastructure.Persistence;
using Xunit;

namespace IntegrationTest.Infrastructure;

[Collection("Tariff Integration Tests")]
public class IntegrationTestBase : IClassFixture<IntegrationTestFixture>
{
	protected ApplicationDbContext DbContext { get; }

	private readonly IntegrationTestFixture _fixture;
	protected IntegrationTestBase(IntegrationTestFixture integrationTestFixture)
	{
		DbContext = integrationTestFixture.DbContext;
		_fixture = integrationTestFixture;

		if (DbContext != null && !DbContext.CheckDataLoaded())
		{
			DbContext.Database.EnsureDeleted();
			DbContext.Database.EnsureCreated();

			DbContext.CreateData();
		}
	}

	public RequestBuilder NewRequest => new(_fixture.HttpClient);
}
