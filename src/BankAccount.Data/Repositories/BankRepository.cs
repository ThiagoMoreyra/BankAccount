using BankAccount.Data.Context;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Shared.Data;

namespace BankAccount.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly BankAccountContext _context;
        public BankRepository(BankAccountContext context)
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
