using MELI.Challenge.Application.Shared.Enum;

namespace MELI.Challenge.Application.Shared
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorType ErrorType { get; set; }

        public static BaseResponse<T> Success(T data)
        {
            return new BaseResponse<T> { IsSuccess = true, Data = data, ErrorType = ErrorType.None };
        }

        public static BaseResponse<T> Failure(string errorMessage, ErrorType errorType)
        {
            return new BaseResponse<T> { IsSuccess = false, ErrorMessage = errorMessage, ErrorType = errorType };
        }
    }
}
