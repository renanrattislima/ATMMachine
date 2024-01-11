using System;

namespace Presentation.Models.Request
{
    public class WithdrawRequest
    {
        public int Value { get; set; }

        public Guid ClientId { get; set; }
    }
}
