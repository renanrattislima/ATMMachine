namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class PaperMoneyRepository : GenericRepository<PaperMoney>, IPaperMoneyRepository
    {
        public PaperMoneyRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<PaperMoney>> GetAvailablePapers()
        {
            return await this._dbContext.PaperMoneys.Where(x => !x.isWithdrawn).ToListAsync();
        }

        public async Task<bool> GetBySerialNumber(string serialNumber)
        {
            return await this._dbContext.PaperMoneys.AnyAsync(x => x.SerialNumber == serialNumber);
        }
    }
}
