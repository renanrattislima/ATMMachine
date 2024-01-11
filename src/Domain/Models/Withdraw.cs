using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Withdraw
    {
        public Guid WithdrawId { get; set; }

        public Guid ClientId { get; set; }

        public Guid PaperId { get; set; }

        public DateTime WithdrawDate { get; set; }

        [NotMapped]
        public Client Client { get; set; }

        [NotMapped]
        public PaperMoney PaperMoney { get; set; }
    }
}
