namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Domain.Interfaces;
    using Domain.Models;

    public class WithdrawService : IWithdrawService
    {
        public IUnitOfWork _unitOfWork;
        public IPaperMoneyRepository _paperMoneyRepository;
        public IWithdrawManager _withdrawManger;

        public WithdrawService(IUnitOfWork unitOfWork, IWithdrawManager withdrawManger, IPaperMoneyRepository paperMoneyRepository)
        {
            _unitOfWork = unitOfWork;
            _withdrawManger = withdrawManger;
            _paperMoneyRepository = paperMoneyRepository;
        }

        public async Task<List<Application.DTOs.Result>> CreateWithdraw(int value, Guid clientId)
        {
            if (value > 0)
            {

                var cashout = await _withdrawManger.RealizarSaquesAsync(clientId, value);

                var billsTospill = new List<Application.DTOs.Result>();
                foreach (var bill in cashout)
                {
                    billsTospill.Add(new DTOs.Result(bill.Item1, bill.Item2));
                }

                if (billsTospill.All(x => x.Success))
                {
                    _unitOfWork.Save();
                }

                return billsTospill;
            }

            return null;
        }

        public async Task<IEnumerable<Withdraw>> GetAllWithdraws()
        {
            var WithdrawList = await _unitOfWork.Withdraws.GetAll();
            return WithdrawList;
        }

        public async Task<Withdraw> GetWithdrawById(Guid withdrawId)
        {
            if (withdrawId != null)
            {
                var Withdraw = await _unitOfWork.Withdraws.GetById(withdrawId);
                if (Withdraw != null)
                {
                    return Withdraw;
                }
            }

            return null;
        }

    }
}
