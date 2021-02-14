using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Owners;

namespace BankAccount.Application.UseCases.RegisterOwner
{
    public class RegisterOwnerUseCase: IRegisterOwnerUseCase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public RegisterOwnerUseCase(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public void RegisterBank(OwnerViewModel ownerViewModel)
        {
            var owner = _mapper.Map<Owner>(ownerViewModel);
            _ownerService.RegisterOwner(owner);
        }
    }
}
