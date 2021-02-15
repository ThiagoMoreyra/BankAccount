using BankAccount.Data.Context;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> Add(BankStatement bankStatement)
        {
            _context.BankStatements.Add(bankStatement);
            return _context.SaveChanges() > 0;
        }        

        public async Task<IEnumerable<BankStatement>> GetAll()
        {
            return await _context.BankStatements.AsNoTracking().ToListAsync();
        }

        public async Task<BankStatement> GetById(Guid id)
        {
            return await _context.BankStatements.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(BankStatement bankStatement)
        {
            _context.Update(bankStatement);
            return _context.SaveChanges() > 0;
        }      

        public async Task<BankStatement> FindByIdAccount(Guid idAccount)
        {
            return await _context.BankStatements.AsNoTracking().OrderByDescending(x => x.TransactionDate).FirstOrDefaultAsync(x => x.IdAccount == idAccount);
        }

        public async Task<IEnumerable<BankStatement>> Find(Guid idAccount)
        {
            return await _context.BankStatements.AsNoTracking().Where(x => x.IdAccount == idAccount).ToListAsync();
        }
    }
}
