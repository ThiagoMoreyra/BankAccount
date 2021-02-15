using System;

namespace BankAccount.Domain.Shared.Data
{
    public interface IRepository<T> where T: Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
