using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Accounts;

namespace BankAccount.Application.UseCases.Accounts
{
    public class OpenAccountUseCase: IOpenAcountUseCase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public OpenAccountUseCase(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public void RegisterAccount(AccountViewModel accountViewModel)
        {
            var account = _mapper.Map<Account>(accountViewModel);
            _accountService.RegisterAccount(account);
        }
    }
}
