using BankAccount.Domain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.BankStatements
{
    public interface IBankStatementRepository : IRepository<BankStatement>
    {
        Task<BankStatement> GetById(Guid id);
        Task<IEnumerable<BankStatement>> GetAll();
        Task<bool> Add(BankStatement bankStatement);
        Task<bool> Update(BankStatement bankStatement);
    }
}
