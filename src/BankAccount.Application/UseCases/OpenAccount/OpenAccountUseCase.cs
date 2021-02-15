using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Shared.Notify;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Accounts
{
    public class OpenAccountUseCase: IOpenAccountUseCase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly INotifiable _notifiable;

        public OpenAccountUseCase(IAccountService accountService, IMapper mapper, INotifiable notifiable)
        {
            _accountService = accountService;
            _mapper = mapper;
            _notifiable = notifiable;
        }

        public async Task<bool> RegisterAccount(AccountViewModel accountViewModel)
        {
            var account = _mapper.Map<Account>(accountViewModel);
            if (account.Invalid)
            {
                _notifiable.AddNotification(new Notification("Register failed - Invalid Fields"));
                return false;
            }                
            return await _accountService.RegisterAccount(account);
        }
    }
}
