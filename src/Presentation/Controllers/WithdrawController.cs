namespace CreditEvaluation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTOs;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawsController : ControllerBase
    {
        public readonly IWithdrawService _WithdrawService;
        public readonly IClientService _ClientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawsController"/> class.
        /// </summary>
        /// <param name="WithdrawService">Withdraw Service Interface.</param>
        /// <param name="clientService">Client Service Interface.</param>
        public WithdrawsController(IWithdrawService WithdrawService, IClientService clientService)
        {
            _WithdrawService = WithdrawService;
            _ClientService = clientService;
        }

        /// <summary>
        /// Get the list of Withdraw.
        /// </summary>
        /// <returns>List of All Withdraws</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Withdraw>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithdrawList()
        {
            var WithdrawDetailsList = await this._WithdrawService.GetAllWithdraws();

            return WithdrawDetailsList != null
                ? this.Ok(WithdrawDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Get Withdraw by id.
        /// </summary>
        /// <param name="withdrawId">Identifier of the Withdraw.</param>
        /// <returns>Withdraw.</returns>
        [HttpGet("{withdrawId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Withdraw))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithdrawById(Guid withdrawId)
        {
            var WithdrawDetailsList = await this._WithdrawService.GetWithdrawById(withdrawId);

            return WithdrawDetailsList != null
                ? this.Ok(WithdrawDetailsList)
                : this.NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<(bool, string)>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterWithdraw([FromBody] Presentation.Models.Request.WithdrawRequest withdrawRequest)
        {
            var result = await this._WithdrawService.CreateWithdraw(withdrawRequest.Value, withdrawRequest.ClientId);

            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                // Se o resultado for nulo, você pode querer retornar um código de status apropriado.
                return this.NotFound(); // Ou qualquer outro código apropriado.
            }
        }
    }
}
