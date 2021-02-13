using BankAccount.Data.Context;
using BankAccount.Domain.Owners;
using BankAccount.Domain.Shared.Data;

namespace BankAccount.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly BankAccountContext _context;
        public OwnerRepository(BankAccountContext context)
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
