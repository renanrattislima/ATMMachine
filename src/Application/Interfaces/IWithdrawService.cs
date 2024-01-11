namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IWithdrawService
    {
        Task<List<Application.DTOs.Result>> CreateWithdraw(int value, Guid clientId);

        Task<IEnumerable<Withdraw>> GetAllWithdraws();

        Task<Withdraw> GetWithdrawById(Guid withdrawId);
    }
}
