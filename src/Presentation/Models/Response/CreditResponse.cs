namespace Presentation.Models.Response
{
    /// <summary>
    /// Credit response model.
    /// </summary>
    public class CreditResponse
    {
        /// <summary>
        /// Status of the requested credit.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Total amount requested of the credit.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Total of fees.
        /// </summary>
        public decimal TotalFees { get; set; }
    }
}
