using BankAccount.Domain.Clients;

namespace BankAccount.Domain.Owners
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void RegisterOwner(Owner owner)
        {
            _ownerRepository.Add(owner);
        }
    }
}
