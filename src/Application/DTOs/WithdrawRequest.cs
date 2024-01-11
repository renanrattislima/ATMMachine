namespace Application.DTOs
{
    using System;
    using Application.DTOs.Enums;

    /// <summary>
    /// Request to register an paper money.
    /// </summary>
    public class WithdrawRequest
    {
        /// <summary>
        ///  Status of withdraw
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///  Status of withdraw
        /// </summary>
        public string Message { get; set; }
    }
}
