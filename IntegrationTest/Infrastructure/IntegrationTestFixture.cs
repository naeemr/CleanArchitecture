using Microsoft.AspNetCore.Mvc.Testing;
using Service;
using Service.Infrastructure.Persistence;
using System;
using System.Net.Http;

namespace IntegrationTest.Infrastructure;

public class IntegrationTestFixture : IDisposable
{
	public readonly ApplicationDbContext DbContext;
	private readonly WebApplicationFactory<Startup> _factory;

	public IntegrationTestFixture()
	{
		try
		{
			_factory = new CustomWebApplicationFactory<Startup>();

			DbContext = _factory.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public void Dispose()
	{
		DbContext?.Dispose();
		_factory.Dispose();
	}

	public HttpClient HttpClient => _factory.CreateClient();
}
