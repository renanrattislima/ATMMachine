namespace Presentation.Models.Request
{
    using System;
    using Application.DTOs.Enums;

    /// <summary>
    /// Request to deposit an paper money.
    /// </summary>
    public class PaperRequest
    {
        /// <summary>
        ///  Value of paper money
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The serial number of the paper money
        /// </summary>
        public string SerialNumber { get; set; }
    }
}
