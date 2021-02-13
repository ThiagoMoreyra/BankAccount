using BankAccount.Data.Context;
using BankAccount.Domain.Shared.Data;
using BankAccount.Domain.Transactions;

namespace BankAccount.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankAccountContext _context;
        public TransactionRepository(BankAccountContext context)
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
