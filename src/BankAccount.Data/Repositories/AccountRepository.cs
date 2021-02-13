using BankAccount.Data.Context;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Shared.Data;

namespace BankAccount.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankAccountContext _context;
        public AccountRepository(BankAccountContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
