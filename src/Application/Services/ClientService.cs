namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Domain.Interfaces;
    using Domain.Models;

    public class ClientService : IClientService
    {
        public IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateClient(Client Client)
        {
            if (Client != null)
            {
                await _unitOfWork.Clients.Add(Client);

                var result = _unitOfWork.Save();

                return result > 0;
            }

            return false;
        }

        public Task<bool> GetByCpfAsync(string cpf)
        {
            return _unitOfWork.Clients.GetByCpfAsync(cpf);
        }

        public async Task<bool> DeleteClient(Guid ClientId)
        {
            if (ClientId != null)
            {
                var Client = await _unitOfWork.Clients.GetById(ClientId);
                if (Client != null)
                {
                    _unitOfWork.Clients.Delete(Client);
                    var result = _unitOfWork.Save();

                    return result > 0;
                }
            }

            return false;
        }

        public Task<IEnumerable<Client>> GetAllClients()
        {
            return _unitOfWork.Clients.GetAllWithRelationships();
        }

        public async Task<Client> GetClientById(Guid ClientId)
        {
            if (ClientId != null)
            {
                var Client = await _unitOfWork.Clients.GetByIdWithRelationships(ClientId);
                if (Client != null)
                {
                    return Client;
                }
            }
            return null;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            if (client != null)
            {
                var Client = await _unitOfWork.Clients.GetById(client.Id);
                if (Client != null)
                {
                    Client.Name = Client.Name;
                    Client.Cellphone = Client.Cellphone;

                    _unitOfWork.Clients.Update(Client);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
