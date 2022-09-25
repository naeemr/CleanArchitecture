namespace Service.Controllers;

public class ProductController : ApiControllerBase
{
    private readonly IProductQueryUseCase _productUseCase;

    public ProductController(IProductQueryUseCase productUseCase)
    {
        _productUseCase = productUseCase;
    }

    [HttpGet]
    [Route("{consumption}")]
    public async Task<IActionResult> GetProducts(int consumption)
    {
        return Ok(await _productUseCase.GetProducts(consumption));
    }
}
