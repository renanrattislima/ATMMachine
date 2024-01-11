namespace Presentation.Models.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.DTOs.Enums;

    /// <summary>
    /// Request to register an paper money.
    /// </summary>
    public class PaperMoneyRequest
    {
        /// <summary>
        ///  Value of paper money
        /// </summary>
        [Required]
        [RegularExpression("100|50|20|10", ErrorMessage = "Paper money value invalid")]
        public int Value { get; set; }

        /// <summary>
        /// The serial number of the paper money
        /// </summary>
        public string SerialNumber { get; set; }
    }
}
