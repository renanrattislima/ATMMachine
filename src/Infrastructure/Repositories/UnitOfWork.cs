namespace Infrastructure.Repositories
{
    using Domain.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;

        public IClientRepository Clients { get; }

        public IWithdrawRepository Withdraws { get; }

        public IPaperMoneyRepository PaperMoneys { get; }

        public UnitOfWork(DbContextClass dbContext,
                            IClientRepository clientRepository,
                            IWithdrawRepository withdrawRepository,
                            IPaperMoneyRepository paperMoneyRepository)
        {
            _dbContext = dbContext;
            Clients = clientRepository;
            Withdraws = withdrawRepository;
            PaperMoneys = paperMoneyRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
