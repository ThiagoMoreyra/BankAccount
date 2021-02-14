using BankAccount.Domain.Clients;

namespace BankAccount.Domain.Owners
{
    public interface IOwnerService
    {
        void RegisterOwner(Owner owner);
    }
}
