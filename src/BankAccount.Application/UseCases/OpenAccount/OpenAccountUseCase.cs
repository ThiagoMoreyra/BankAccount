using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Accounts;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Accounts
{
    public class OpenAccountUseCase: IOpenAccountUseCase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public OpenAccountUseCase(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAccount(AccountViewModel accountViewModel)
        {
            var account = _mapper.Map<Account>(accountViewModel);
            return await _accountService.RegisterAccount(account);
        }
    }
}
