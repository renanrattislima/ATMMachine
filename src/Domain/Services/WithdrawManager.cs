namespace Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;

    public class WithdrawManager : IWithdrawManager
    {
        private readonly IPaperMoneyRepository paperMoneyRepository;
        private readonly IClientRepository clientRepository;
        private readonly IWithdrawRepository withdrawRepository;

        public WithdrawManager(IPaperMoneyRepository paperMoneyRepository, IClientRepository clientRepository, IWithdrawRepository withdrawRepository)
        {
            if (paperMoneyRepository is null)
            {
                throw new ArgumentNullException(nameof(paperMoneyRepository));
            }

            this.paperMoneyRepository = paperMoneyRepository;
            this.clientRepository = clientRepository;
            this.withdrawRepository = withdrawRepository;
        }

        public async Task<List<(bool, string)>> RealizarSaquesAsync(Guid usuarioId, int valorSaque)
        {
            var notasDisponiveis = await paperMoneyRepository.GetAvailablePapers();

            // Lista para armazenar os resultados
            List<(bool, string)> resultados = new List<(bool, string)>();

            // Para cada nota disponível, cria um registro de Withdraw
            foreach (var nota in notasDisponiveis.OrderByDescending(x => x.Value))
            {
                int quantidadeNotas = valorSaque / nota.Value;

                if (quantidadeNotas > 0 && !nota.isWithdrawn)
                {
                    var resultado = await CreateWithdrawRegisterAsync(usuarioId, nota.PaperId);
                    resultados.Add(resultado);

                    valorSaque -= nota.Value;
                }
            }

            return resultados.Count == 0 || valorSaque > 0 ? new List<(bool, string)> { (false, "Unable to withdraw at this time") } : resultados;
        }

        private async Task<(bool, string)> CreateWithdrawRegisterAsync(Guid usuarioId, Guid notaId)
        {
            try
            {
                var cleint = await clientRepository.GetById(usuarioId);
                var paperMoney = await paperMoneyRepository.GetById(notaId);

                if (cleint == null || paperMoney == null)
                {
                    return (false, "User or note not found.");
                }

                var withdraw = new Withdraw
                {
                    ClientId = usuarioId,
                    PaperId = notaId,
                    WithdrawDate = DateTime.Now
                };

                paperMoney.isWithdrawn = true;

                await withdrawRepository.Add(withdraw);
                paperMoneyRepository.Update(paperMoney);

                return (true, $"Paper money " + paperMoney.Value + " Serial Number: " + paperMoney.SerialNumber);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao processar a retirada: {ex.Message}");
            }
        }
    }
}
