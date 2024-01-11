using System;

namespace Application.DTOs
{
    public class Withdraw
    {
        public Guid WithdrawId { get; set; }

        public Guid ClientId { get; set; }

        public Guid PaperId { get; set; }

        public DateTime WithdrawDate { get; set; }
    }
}
