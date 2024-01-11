namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IClientService
    {
        Task<bool> CreateClient(Client ClientDetails);

        Task<bool> GetByCpfAsync(string cpf);

        Task<IEnumerable<Client>> GetAllClients();

        Task<Client> GetClientById(Guid ClientId);

        Task<bool> UpdateClient(Client ClientDetails);

        Task<bool> DeleteClient(Guid ClientId);
    }
}
