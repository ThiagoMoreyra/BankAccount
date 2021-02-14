using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.Transactions;
using System;

namespace BankAccount.Application.UseCases.Pays
{
    public class PayUseCase : IPayUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IBankService _bankService;
        private readonly IAccountService _accountService;

        public PayUseCase(IBankStatementService bankStatementService, IBankService bankService, IAccountService accountService)
        {
            _bankStatementService = bankStatementService;
            _bankService = bankService;
            _accountService = accountService;
        }

        public void Pay(Guid idAccount, double amount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            var bank = _bankService.GetBankById(account.IdBank);

            if (account.Valid && bank.Valid)
            {
                Pay pay = new Pay(amount, DateTime.Now, account, bank);
                var result = pay.Execute();
                if (result > 0)
                {
                    _accountService.UpdateAccount(account);
                    var bankStatement = new BankStatement(TransactionType.Pay, DateTime.Now, amount, account.Id, account.IdOwner);
                    _bankStatementService.RegisterBankStatement(bankStatement);
                }
            }
        }
    }
}
