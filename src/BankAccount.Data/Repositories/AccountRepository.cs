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

        public async Task<bool> Add(Account account)
        {
            _context.Accounts.Add(account);
            return _context.SaveChanges() > 0;
        }       

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.AsNoTracking().ToListAsync();
        }

        public async Task<Account> GetById(Guid id)
        {
            return await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(Account account)
        {
            _context.Update(account);
            return _context.SaveChanges() > 0;
        }       
    }
}
