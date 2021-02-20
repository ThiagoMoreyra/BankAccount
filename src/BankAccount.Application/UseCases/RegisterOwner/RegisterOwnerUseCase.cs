using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Owners;
using BankAccount.Domain.Owners.Services;
using BankAccount.Domain.Shared.Notify;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.RegisterOwner
{
    public class RegisterOwnerUseCase: IRegisterOwnerUseCase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;
        private readonly INotifiable _notifiable;

        public RegisterOwnerUseCase(IOwnerService ownerService, IMapper mapper, INotifiable notifiable)
        {
            _ownerService = ownerService;
            _mapper = mapper;
            _notifiable = notifiable;
        }

        public async Task<bool> RegisterOwner(OwnerViewModel ownerViewModel)
        {
            var owner = _mapper.Map<Owner>(ownerViewModel);
            if (owner.Invalid)
            {
                _notifiable.AddNotification(new Notification("Register failed - Invalid Fields"));
                return false;
            }            
            return await _ownerService.RegisterOwner(owner);
        }
    }
}
