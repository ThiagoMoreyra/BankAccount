using BankAccount.Data.Context;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
        }       

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.AsNoTracking().ToListAsync();
        }

        public async Task<Account> GetById(Guid id)
        {
            return await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
