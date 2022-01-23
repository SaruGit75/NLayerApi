using System.Text.Json.Serialization;

namespace NLayerApi.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        [JsonIgnore]
        public int StatusCode { get; set; }

        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        
        
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                Errors = null
            };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode
            };
        }

        public static CustomResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode
            };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Errors = new List<string>{error}
            };
        }
    }
}
