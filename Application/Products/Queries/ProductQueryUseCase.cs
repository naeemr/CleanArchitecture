using Domain.ProductAggregate.Tariffs;

namespace Application.Products.Queries;

public class ProductQueryUseCase : IProductQueryUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly ITariffFactory _tariffFactory;

    public ProductQueryUseCase(IProductRepository productRepository,
        ITariffFactory tariffFactory)
    {
        _productRepository = productRepository;
        _tariffFactory = tariffFactory;
    }

    public async Task<List<GetProducts>> GetProducts(int consumption)
    {
        List<GetProducts> response = new();

        var products = await _productRepository.GetProducts();

        foreach (var product in products)
        {
            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, consumption);

            response.Add(new GetProducts(product.Name, annualCost));
        }

        response = response.OrderBy(p => p.AnnualCost).ToList();

        return response;
    }

    public async Task<GetProductById> GetProductById(int id)
    {

        return await Task.FromResult<GetProductById>(default);
    }
}
