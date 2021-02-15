using BankAccount.Domain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.Accounts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetById(Guid id);
        Task<IEnumerable<Account>> GetAll();
        Task<bool> Add(Account account);
        Task<bool> Update(Account account);
    }
}
