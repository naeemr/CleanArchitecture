using Domain.ProductAggregate.Tariffs;

namespace Application.Products.Queries;

public interface IProductQueryUseCase
{
    Task<IEnumerable<GetProducts>> GetProducts(int consumption);
}

public class ProductQueryUseCase : IProductQueryUseCase
{
    private readonly IProductQueryRepository _productRepository;
    private readonly ITariffFactory _tariffFactory;

    public ProductQueryUseCase(IProductQueryRepository productRepository,
        ITariffFactory tariffFactory)
    {
        _productRepository = productRepository;
        _tariffFactory = tariffFactory;
    }

    public async Task<IEnumerable<GetProducts>> GetProducts(int consumption)
    {
        List<GetProducts> response = new();

        if (consumption < 0)
        {
            return response;
        }

        var products = await _productRepository.GetProducts();

        if (products?.Any() == true)
        {
            foreach (var product in products)
            {
                var tariff = _tariffFactory.Create(product.Type);

                var annualCost = tariff.CalculateAnnualCost(product, consumption);

                response.Add(new GetProducts(product.Name, annualCost));
            }
        }

        return response.OrderBy(p => p.AnnualCost);
    }
}
