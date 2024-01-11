namespace Domain.Interfaces
{
    using Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPaperMoneyRepository : IGenericRepository<PaperMoney>
    {
        Task<bool> GetBySerialNumber(string serialNumber);

        Task<IEnumerable<PaperMoney>> GetAvailablePapers();
    }
}
