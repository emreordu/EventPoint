using System.Net;

namespace EventPoint.Business
{
    public class  APIResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public Error ErrorMessages { get; set; }
        public T Result{ get; set; }
    }

    public class Error
    {
        public string ErrorMessage { get; set; }
    }
}