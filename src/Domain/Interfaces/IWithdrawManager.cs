namespace Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IWithdrawManager
    {
        Task<List<(bool, string)>> RealizarSaquesAsync(Guid usuarioId, int valorSaque);

    }
}
