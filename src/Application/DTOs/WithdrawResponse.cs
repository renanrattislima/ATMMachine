namespace Application.DTOs
{
    /// <summary>
    /// Paper Money Response.
    /// </summary>
    public class WithdrawResponse
    {
        /// <summary>
        /// Status of the requested paper money register.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Message of the transaction.
        /// </summary>
        public string Message { get; set; }
    }
}
