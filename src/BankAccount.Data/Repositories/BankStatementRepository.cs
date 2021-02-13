using BankAccount.Data.Context;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Shared.Data;

namespace BankAccount.Data.Repositories
{
    public class BankStatementRepository : IBankStatementRepository
    {
        private readonly BankAccountContext _context;
        public BankStatementRepository(BankAccountContext context)
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
