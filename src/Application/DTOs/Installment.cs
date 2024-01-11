namespace Application.DTOs
{
    using System;
    using System.Text.Json.Serialization;
    using Microsoft.VisualBasic;

    public class Installment
    {
        public Guid Id { get; set; }

        public Guid LoanId { get; set; } // Reference to the Financing's Id

        public int InstallmentNumber { get; set; }

        public decimal InstallmentAmount { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [JsonIgnore]
        public Loan Loan { get; set; }
    }
}
