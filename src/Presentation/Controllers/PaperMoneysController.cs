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
    public class PaperMoneysController : ControllerBase
    {
        public readonly IPaperMoneyService _PaperMoneyService;
        public readonly IClientService _ClientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaperMoneysController"/> class.
        /// </summary>
        /// <param name="PaperMoneyService">PaperMoney Service Interface.</param>
        /// <param name="clientService">Client Service Interface.</param>
        public PaperMoneysController(IPaperMoneyService PaperMoneyService, IClientService clientService)
        {
            _PaperMoneyService = PaperMoneyService;
            _ClientService = clientService;
        }

        /// <summary>
        /// Get the list of PaperMoney.
        /// </summary>
        /// <returns>List of All PaperMoneys</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PaperMoney>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaperMoneyList()
        {
            var PaperMoneyDetailsList = await this._PaperMoneyService.GetAllPaperMoneys();

            return PaperMoneyDetailsList != null
                ? this.Ok(PaperMoneyDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Get PaperMoney by id.
        /// </summary>
        /// <param name="PaperMoneyId">Identifier of the PaperMoney.</param>
        /// <returns>PaperMoney.</returns>
        [HttpGet("{PaperMoneyId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaperMoney))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaperMoneyById(Guid PaperMoneyId)
        {
            var PaperMoneyDetailsList = await this._PaperMoneyService.GetPaperMoneyById(PaperMoneyId);

            return PaperMoneyDetailsList != null
                ? this.Ok(PaperMoneyDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Register a new PaperMoney
        /// </summary>
        /// <param name="paperMoneyRequests">PaperMoney request list model (Value,Serial Number)</param>
        /// <returns>bool.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PaperMoney))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterPaperMoney(List<PaperMoneyRequest> paperMoneyRequests)
        {
            List<Task<(bool, string)>> tasks = new List<Task<(bool, string)>>();

            foreach (var paperMoneyRequest in paperMoneyRequests)
                tasks.Add(_PaperMoneyService.RegisterPaperMoney(paperMoneyRequest.ToApplication()));

            var resultLists = await Task.WhenAll(tasks);

            foreach (var resultado in resultLists)
            {
                Console.WriteLine($"Success: {resultado.Item1}, Message: {resultado.Item2}");
            }

            return this.Ok(resultLists);
        }
    }
}
