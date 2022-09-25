namespace Service.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductQueryUseCase _productUseCase;

    public ProductController(IProductQueryUseCase productUseCase)
    {
        _productUseCase = productUseCase;
    }

    [HttpGet]
    [Route("{consumption}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts(int consumption)
    {
        return Ok(await _productUseCase.GetProducts(consumption));
    }
}
