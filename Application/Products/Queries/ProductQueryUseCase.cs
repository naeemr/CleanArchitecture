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

    public async Task<ApiResponse<List<GetProducts>>> GetProducts(int consumption)
    {
        var response = new ApiResponse<List<GetProducts>>();

        if (consumption < 0)
        {
            response.Error = new ApiError(0, "Consumption cannot be zero");
            response.Success = false;
            return response;
        }

        var products = await _productRepository.GetProducts();

        response.Result = new();

        foreach (var product in products)
        {
            var tariff = _tariffFactory.Create(product.Type);

            var annualCost = tariff.CalculateAnnualCost(product, consumption);

            response.Result.Add(new GetProducts(product.Name, annualCost));
        }

        response.Result = response.Result.OrderBy(p => p.AnnualCost).ToList();

        return response;
    }

    public async Task<ApiResponse<GetProductById>> GetProductById(int id)
    {
        var response = new ApiResponse<GetProductById>();


        return response;
    }
}
