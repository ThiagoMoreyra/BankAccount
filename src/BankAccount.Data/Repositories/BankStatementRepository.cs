using BankAccount.Data.Context;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public void Add(BankStatement bankStatement)
        {
            _context.BankStatements.Add(bankStatement);
        }        

        public async Task<IEnumerable<BankStatement>> GetAll()
        {
            return await _context.BankStatements.AsNoTracking().ToListAsync();
        }

        public async Task<BankStatement> GetById(Guid id)
        {
            return await _context.BankStatements.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(BankStatement bankStatement)
        {
            _context.BankStatements.Update(bankStatement);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
