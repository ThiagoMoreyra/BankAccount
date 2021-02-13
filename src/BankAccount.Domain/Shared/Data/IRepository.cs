using System;

namespace BankAccount.Domain.Shared.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
