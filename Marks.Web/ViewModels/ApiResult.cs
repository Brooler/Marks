namespace Marks.Web.ViewModels
{
    /// <summary>
    /// Api result with "Result" of type T
    /// </summary>
    /// <typeparam name="T">Type of result</typeparam>
    public class ApiResult<T> : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="successful">Was operation successful</param>
        /// <param name="result">Result of operation</param>
        /// <param name="errorMessage">Error message</param>
        public ApiResult(bool successful, T result, string errorMessage = null) 
            : base(successful, errorMessage)
        {
            Result = result;
        }

        /// <summary>
        /// Api response data.
        /// </summary>
        public T Result { get; set; }
    }

    /// <summary>
    /// Api result.
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="successful">Was operation successful</param>
        /// <param name="errorMessage">Error message</param>
        public ApiResult(bool successful, string errorMessage = null)
        {
            Successful = successful;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Was operation successful.
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Success operation without response data.
        /// </summary>
        /// <returns>Success api result</returns>
        public static ApiResult SuccessResult()
        {
            return new ApiResult(true);
        }

        /// <summary>
        /// Success operation with response data.
        /// </summary>
        /// <typeparam name="T">Type of response data</typeparam>
        /// <param name="result">Response data</param>
        /// <returns>Success api result with response data</returns>
        public static ApiResult<T> SuccessResult<T>(T result)
        {
            return new ApiResult<T>(true, result);
        }

        /// <summary>
        /// Failed operation.
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <returns>Fail result with error message</returns>
        public static ApiResult FailResult(string errorMessage)
        {
            return new ApiResult(false, errorMessage);
        }
    }
}
