using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.Owners
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Task<Owner> GetById(Guid id);
        Task<IEnumerable<Owner>> GetAll();
        Task<bool> Add(Owner owner);
        Task<bool> Update(Owner owner);
    }
}
