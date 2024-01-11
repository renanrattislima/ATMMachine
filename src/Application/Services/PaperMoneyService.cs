namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTOs;
    using Application.Interfaces;
    using Application.Mappers;
    using Domain.Interfaces;

    public class PaperMoneyService : IPaperMoneyService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IPaperMoneyRepository _paperMoneyRepository;

        public PaperMoneyService(IUnitOfWork unitOfWork, IPaperMoneyRepository paperMoneyRepository)
        {
            _unitOfWork = unitOfWork;
            _paperMoneyRepository = paperMoneyRepository;
        }

        public async Task<(bool, string)> RegisterPaperMoney(PaperMoney PaperMoney)
        {
            if (PaperMoney != null)
            {
                var exists = await _paperMoneyRepository.GetBySerialNumber(PaperMoney.SerialNumber);

                if (exists)
                {
                    return (false, "This serial number has already been registered");
                }

                await _unitOfWork.PaperMoneys.Add(PaperMoney.ToDomain());

                var result = _unitOfWork.Save();

                return (result > 0, result > 0 ? "Success" : "Error");
            }

            return (false, "");
        }

        public async Task<IEnumerable<PaperMoney>> GetAllPaperMoneys()
        {
            return _paperMoneyRepository.GetAvailablePapers().GetAwaiter().GetResult().ToApplication();
        }

        public async Task<PaperMoney> GetPaperMoneyById(Guid PaperMoneyId)
        {
            if (PaperMoneyId != null)
            {
                var PaperMoney = await _unitOfWork.PaperMoneys.GetById(PaperMoneyId);
                if (PaperMoney != null)
                {
                    return PaperMoney.ToApplication();
                }
            }

            return null;
        }
    }
}
