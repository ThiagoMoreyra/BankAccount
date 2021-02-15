using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Shared.Notify;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Banks
{
    public class RegisterBankUseCase: IRegisterBankUseCase
    {
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;
        private readonly INotifiable _notifiable;

        public RegisterBankUseCase(IBankService bankService, IMapper mapper, INotifiable notifiable)
        {
            _bankService = bankService;
            _mapper = mapper;
            _notifiable = notifiable;
        }

        public async Task<bool> RegisterBank(BankViewModel bankViewModel)
        {
            var bank = _mapper.Map<Bank>(bankViewModel);
            if (bank.Invalid)
            {
                _notifiable.AddNotification(new Notification("Register failed - Invalid Fields"));
                return false;
            }
            
            return await _bankService.RegisterBank(bank);
        }
    }
}
