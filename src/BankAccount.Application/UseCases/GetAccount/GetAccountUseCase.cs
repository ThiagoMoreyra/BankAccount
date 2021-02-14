using BankAccount.Domain.Accounts;
using System;

namespace BankAccount.Application.UseCases.GetAccount
{
    public class GetAccountUseCase : IGetAccountUseCase
    {
        private readonly IAccountService _accountService;
        
        public GetAccountUseCase(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        public decimal GetAvaliableAccount(double fee, Guid idAccount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            return _accountService.GetAvaliableBalance(fee, account);
        }
    }
}
