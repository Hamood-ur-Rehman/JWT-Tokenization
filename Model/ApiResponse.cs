namespace Jwt_Authentication.Model
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; } = 0;
        public string Message { get; set; } = "Success";
        public T Data { get; set; }
    }
}
