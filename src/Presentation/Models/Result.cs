namespace Presentation.Models
{
    // Result.cs
    public class Result<T>
    {
        /// <summary>
        /// Booleand indicates response status.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Message of response.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Object of result.
        /// </summary>
        public T Data { get; }


        public Result(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
