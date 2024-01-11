namespace Domain.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }

        IPaperMoneyRepository PaperMoneys { get; }

        IWithdrawRepository Withdraws { get; }

        int Save();
    }
}
