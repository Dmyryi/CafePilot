namespace CafePilot.Server.Responses
{
    public class ErrorResponse
    {
        public string Status { get; set; } = "error";
        public ErrorDetail Error { get; set; }
    }

    public class ErrorDetail
    {
       
        public string Message { get; set; }
    }
}
