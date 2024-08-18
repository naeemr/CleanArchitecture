using Microsoft.EntityFrameworkCore;
using Service.Domain.ProviderAggregate.Tariffs;
using Service.Infrastructure.Persistence;

namespace Service.Application.Products;

public class ProductUseCase : IProductUseCase
{
	private readonly ITariffFactory _tariffFactory;
	private readonly ApplicationDbContext _context;

	public ProductUseCase(ITariffFactory tariffFactory,
		ApplicationDbContext context)
	{
		_tariffFactory = tariffFactory;
		_context = context;
	}

	public async Task<List<ProductModel>> GetProducts(int consumption)
	{
		List<ProductModel> response = new();

		var products = await _context.Products.ToListAsync();

		foreach (var product in products)
		{
			var tariff = _tariffFactory.Create(product.Type);

			var annualCost = tariff.CalculateAnnualCost(product, consumption);

			response.Add(new ProductModel(product.Provider,
				product.ProductName,
				product.TariffName,
				product.BaseCost,
				product.CostPerKWh,
				annualCost,
				product.AllowedConsumption,
				product.BaseCostPeriod));
		}

		response = response.OrderBy(p => p.TotalAnnualCost).ToList();

		return response;
	}

	public async Task<ProductById> GetProductById(int id)
	{
		return await Task.FromResult<ProductById>(default);
	}
}
