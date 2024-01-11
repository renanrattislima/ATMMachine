namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Cliente model.
    /// </summary>
    public class Client
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public string UF { get; set; }

        public string Cellphone { get; set; }

        [NotMapped]
        public List<Withdraw> Withdraws { get; set; }
    }
}
