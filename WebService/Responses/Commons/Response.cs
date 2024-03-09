namespace WebService.Responses.Commons
{
    public class DataResponse<T>:Response
    {
        public T Data { get; set; }
        public DataResponse(T data, string message,bool success):base(message,success)
        {
            Data=data;
        }
    }

    public class Response
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Response(string message, bool success)
        {
            Message=message;
            Success=success;
        }
    }
}