namespace MELI.Challenge.Application.Shared
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public static BaseResponse<T> Success(T data)
        {
            return new BaseResponse<T> { IsSuccess = true, Data = data };
        }

        public static BaseResponse<T> Failure(string errorMessage)
        {
            return new BaseResponse<T> { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }
}
