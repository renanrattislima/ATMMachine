namespace Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> GetByIdWithRelationships(Guid id);

        Task<IEnumerable<Client>> GetAllWithRelationships();

        Task<bool> GetByCpfAsync(string cpf);
    }
}
