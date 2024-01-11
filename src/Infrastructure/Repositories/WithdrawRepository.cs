namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;

    public class WithdrawRepository : GenericRepository<Withdraw>, IWithdrawRepository
    {
        public WithdrawRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
