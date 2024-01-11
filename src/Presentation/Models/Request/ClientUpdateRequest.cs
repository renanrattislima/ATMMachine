namespace Presentation.Models.Request
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Cliente model.
    /// </summary>
    public class ClientUpdateRequest
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public string UF { get; set; }

        public string Cellphone { get; set; }
    }
}
