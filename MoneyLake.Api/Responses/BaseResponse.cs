namespace MoneyLake.Api.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        
        public string ErrorMessage { get; set; }

        public static BaseResponse Success()
        {
            return Success<BaseResponse>();
        }
        
        public static T Success<T>() where T: BaseResponse, new()
        {
            return new T
            {
                IsSuccess = true
            };
        }
        
        public static BaseResponse Failure(string errorMessage = "")
        {
            return Failure<BaseResponse>(errorMessage);
        }
        
        public static T Failure<T>(string errorMessage = "") where T: BaseResponse, new()
        {
            return new T
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
