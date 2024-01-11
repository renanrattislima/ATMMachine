namespace CreditEvaluation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTOs;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Presentation.Mappers;
    using Presentation.Models.Request;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="clientService">Client Service.</param>
        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        /// <summary>
        /// Get All clients.
        /// </summary>
        /// <returns>List of clients.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Client>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientList()
        {
            var clientDetailsList = await this.clientService.GetAllClients();

            return clientDetailsList != null
                ? this.Ok(clientDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Get client by identifier.
        /// </summary>
        /// <param name="clientId">Guid of the client identifier.</param>
        /// <returns>Client.</returns>
        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientById(Guid clientId)
        {
            var clientDetails = await this.clientService.GetClientById(clientId);

            return clientDetails != null
                ? this.Ok(clientDetails)
                : this.BadRequest();
        }

        /// <summary>
        /// Create a new client.
        /// </summary>
        /// <param name="clientDetails">Client parameters (CPF, Name, UF, Cellphone).</param>
        /// <returns>bool.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClient(ClientRequest clientDetails)
        {
            var clientExists = await this.clientService.GetByCpfAsync(clientDetails.CPF);

            if (clientExists)
            {
                return this.BadRequest("Cpf already exists in the database");
            }

            var isClientCreated = await this.clientService.CreateClient(clientDetails.ToDomain());

            return isClientCreated
                ? this.Ok(isClientCreated)
                : this.BadRequest();
        }

        /// <summary>
        /// Update client informatio.
        /// </summary>
        /// <param name="clientDetails">Client parameters (CPF, Name, UF, Cellphone).</param>
        /// <returns>bool.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateClient(ClientUpdateRequest clientDetails)
        {
            if (clientDetails != null)
            {
                var isClientUpdated = await this.clientService.UpdateClient(clientDetails.ToDomain());

                return isClientUpdated
                    ? this.Ok(isClientUpdated)
                    : this.BadRequest();
            }

            return this.BadRequest();
        }

        /// <summary>
        /// Delete client information.
        /// </summary>
        /// <param name="clientId">Guid identifier of the Client.</param>
        /// <returns>bool.</returns>
        [HttpDelete("{clientId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var isClientDeleted = await this.clientService.DeleteClient(clientId);

            return isClientDeleted
                ? this.Ok(isClientDeleted)
                : this.BadRequest();
        }
    }
}