using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.Transactions;
using System;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Deposits
{
    public class DepositUseCase : IDepositUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IBankService _bankService;
        private readonly IAccountService _accountService;

        public DepositUseCase(IBankStatementService bankStatementService, IBankService bankService, IAccountService accountService)
        {
            _bankStatementService = bankStatementService;
            _bankService = bankService;
            _accountService = accountService;
        }

        public async Task<bool> Deposit(Guid idAccount, double amount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            var bank = _bankService.GetBankById(account.IdBank);

            if (account.Invalid && bank.Invalid) return false;

            Deposit deposit = new Deposit(amount, DateTime.Now, account, bank);
            var insertedAccount = false;
            var insertedBankStatement = false;

            var result = deposit.Execute();
            if (result > 0)
            {
                insertedAccount = await _accountService.UpdateAccount(account);
                if (insertedAccount)
                {
                    var bankStatement = new BankStatement(TransactionType.Deposit, DateTime.Now, amount, account.Id, account.IdOwner);
                    insertedBankStatement =  await _bankStatementService.RegisterBankStatement(bankStatement);
                }
            }

            return (insertedAccount && insertedBankStatement);
        }
    }
}
