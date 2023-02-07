using EventPoint.DataAccess.IdentityServer.Dto;
using System.Text.Json.Serialization;

namespace EventPoint.DataAccess.IdentityServer
{
    public class ResponseDTO<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public ErrorDTO Error { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public static ResponseDTO<T> Success(T data, int statusCode)
        {
            return new ResponseDTO<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDTO<T> Success(int statusCode)
        {
            return new ResponseDTO<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDTO<T> Fail(ErrorDTO errorDTO, int statusCode)
        {
            return new ResponseDTO<T> { Error = errorDTO, StatusCode = statusCode, IsSuccessful = false };
        }
        public static ResponseDTO<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDTO(errorMessage, isShow);
            return new ResponseDTO<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}