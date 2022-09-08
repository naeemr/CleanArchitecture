namespace Service.Controllers;

public class ProductController : ApiControllerBase
{
    private readonly IGetProductsHandler _productsHandler;

    public ProductController(IGetProductsHandler productsHandler)
    {
        _productsHandler = productsHandler;
    }

    [HttpGet]
    [Route("{consumption}")]
    public async Task<IActionResult> GetProducts(int consumption)
    {
        return Ok(await _productsHandler.Handle(consumption));
    }
}
