using BankAccount.Domain.Clients;
using System.Threading.Tasks;

namespace BankAccount.Domain.Owners
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<bool> RegisterOwner(Owner owner)
        {
            if (owner.Invalid) return false;

            return await _ownerRepository.Add(owner);
        }
    }
}
