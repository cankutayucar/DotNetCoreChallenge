using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetChallenge.Application.Wrappers
{
    public class CustomResponse<T> where T : class
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public CustomError? Error { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        public static CustomResponse<T> Success(T data, int statusCode)
        {
            return new CustomResponse<T> { Data = data, IsSuccessful = true, StatusCode = statusCode };
        }

        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { Data = default, IsSuccessful = true, StatusCode = statusCode };
        }

        public static CustomResponse<T> Fail(CustomError errorDto, int statusCode)
        {
            return new CustomResponse<T> { Error = errorDto, IsSuccessful = false, StatusCode = statusCode };
        }

        public static CustomResponse<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            return new CustomResponse<T>
                { Error = new CustomError(errorMessage, isShow), IsSuccessful = false, StatusCode = statusCode };
        }
    }
}
