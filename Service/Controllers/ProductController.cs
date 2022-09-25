namespace Service.Controllers;

public class ProductController : ApiBaseController
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
        if (consumption < 0)
        {
            return BadRequest(new ApiError(0, "Consumption cannot be zero"));
        }

        return Ok(await _productUseCase.GetProducts(consumption));
    }
}
