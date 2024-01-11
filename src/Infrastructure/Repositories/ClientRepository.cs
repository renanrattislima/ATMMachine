namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContextClass dbContext) : base(dbContext)
        {
        }

        public async Task<bool> GetByCpfAsync(string cpf)
        {
            return await this._dbContext.Clients.AnyAsync(x => x.CPF == cpf);
        }

        public async Task<IEnumerable<Client>> GetAllWithRelationships()
        {
            return await this._dbContext.Clients.Include(c => c.Withdraws).ToListAsync();
        }

        public async Task<Client> GetByIdWithRelationships(Guid id)
        {
            return await this._dbContext.Clients
             .Where(c => c.Id == id)
             .Include(c => c.Withdraws)
             .FirstOrDefaultAsync();
        }
    }
}
