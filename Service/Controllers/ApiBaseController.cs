using Microsoft.AspNetCore.Mvc.Infrastructure;
using Service.Application.Common.Model;

namespace Service.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiBaseController : ControllerBase
{
	public override OkObjectResult Ok([ActionResultObjectValue] object value)
	{
		ApiResponse<object> response = new();

		response.Result = value;

		response.StatusCode = StatusCodes.Status200OK;

		return base.Ok(response);
	}

	public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object error)
	{
		ApiResponse<object> response = new();

		response.Error = (ApiError)error;

		response.StatusCode = StatusCodes.Status400BadRequest;

		response.Success = false;

		return base.BadRequest(response);
	}

	public override ConflictObjectResult Conflict([ActionResultObjectValue] object error)
	{
		ApiResponse<object> response = new();

		response.Error = (ApiError)error;

		response.StatusCode = StatusCodes.Status409Conflict;

		response.Success = false;

		return base.Conflict(response);
	}
}
