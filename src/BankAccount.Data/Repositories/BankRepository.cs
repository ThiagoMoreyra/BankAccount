using BankAccount.Data.Context;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public void Add(Bank bank)
        {
            _context.Banks.Add(bank);
        }       

        public async Task<IEnumerable<Bank>> GetAll()
        {
            return await _context.Banks.AsNoTracking().ToListAsync();
        }

        public async Task<Bank> GetById(Guid id)
        {
            return await _context.Banks.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Bank bank)
        {
            _context.Banks.Update(bank);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
