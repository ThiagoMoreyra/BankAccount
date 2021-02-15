using BankAccount.Domain.Clients;
using System.Threading.Tasks;

namespace BankAccount.Domain.Owners
{
    public interface IOwnerService
    {
        Task<bool> RegisterOwner(Owner owner);
    }
}
