namespace Service.Application.Common.Model;

public class ApiResponse<T>
	where T : class
{
	public bool Success { get; set; } = true;
	public int StatusCode { get; set; }
	public T Result { get; set; }
	public ApiError Error { get; set; }
}
