using BankAccount.Domain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.Transactions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<Transaction> GetById(Guid id);
        Task<IEnumerable<Transaction>> GetAll();
        Task<bool> Add(Transaction transaction);
        Task<bool> Update(Transaction transaction);
    }
}
