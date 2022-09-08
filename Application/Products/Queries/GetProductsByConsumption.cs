namespace Application.Products.Queries;

public interface IGetProductsHandler
{
    Task<IEnumerable<ProductDTO>> Handle(int consumption);
}

public class GetProductsHandler : IGetProductsHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ITariffFactory _tariffFactory;

    public GetProductsHandler(IProductRepository productRepository,
        ITariffFactory tariffFactory)
    {
        _productRepository = productRepository;
        _tariffFactory = tariffFactory;
    }

    public async Task<IEnumerable<ProductDTO>> Handle(int consumption)
    {
        List<ProductDTO> response = new();

        if (consumption < 0)
        {
            return response;
        }

        var products = await _productRepository.GetAllAsync();
        
        if (products?.Any() == true)
        {
            foreach (var product in products)
            {
                var tariff = _tariffFactory.Create(product.Type);

                var annualCost = tariff.CalculateAnnualCost(product, consumption);

                response.Add(new ProductDTO(product.Name, annualCost));
            }
        }

        return response.OrderBy(p => p.AnnualCost);
    }
}
