namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;
    using Application.DTOs;

    public interface IPaperMoneyService
    {
        Task<(bool, string)> RegisterPaperMoney(PaperMoney PaperMoneyDetails);

        Task<IEnumerable<PaperMoney>> GetAllPaperMoneys();

        Task<PaperMoney> GetPaperMoneyById(Guid PaperMoneyId);
    }
}
