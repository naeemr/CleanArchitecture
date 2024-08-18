using Service.Application.Common.Model;
using Service.Application.Products;

namespace Service.Controllers;

public class ProductController : ApiBaseController
{
	private readonly IProductUseCase _productUseCase;

	public ProductController(IProductUseCase productUseCase)
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

		var products = await _productUseCase.GetProducts(consumption);

		return Ok(products);
	}
}
