using BankAccount.Data.Context;
using BankAccount.Domain.Shared.Data;
using BankAccount.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }        

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task<Transaction> GetById(Guid id)
        {
            return await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
