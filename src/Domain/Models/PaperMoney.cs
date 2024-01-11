namespace Domain.Models
{
    using System;

    public class PaperMoney
    {
        public Guid PaperId { get; set; }

        public int Value { get; set; }

        public string SerialNumber { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool isWithdrawn { get; set; }
    }
}
