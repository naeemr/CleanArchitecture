namespace Application.Common.Model;

public class ApiError
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public string Help { get; set; }

    public ApiError()
    {

    }

    public ApiError(int code, string message, string help = "")
    {
        ErrorCode = code;
        ErrorMessage = message;
        Help = help;
    }
}
