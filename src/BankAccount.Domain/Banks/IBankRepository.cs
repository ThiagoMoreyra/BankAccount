using BankAccount.Domain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.Banks
{
    public interface IBankRepository : IRepository<Bank>
    {
        Task<Bank> GetById(Guid id);
        Task<IEnumerable<Bank>> GetAll();
        void Add(Bank account);
        void Update(Bank account);
    }
}
