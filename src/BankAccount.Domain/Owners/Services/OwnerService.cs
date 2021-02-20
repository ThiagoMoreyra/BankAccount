using BankAccount.Domain.Clients;
using System.Threading.Tasks;

namespace BankAccount.Domain.Owners.Services
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
            return await _ownerRepository.Add(owner);
        }
    }
}
