using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.Shared.Notify;
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
        private readonly INotifiable _notifiable;

        public DepositUseCase(IBankStatementService bankStatementService, IBankService bankService, IAccountService accountService, INotifiable notifiable)
        {
            _bankStatementService = bankStatementService;
            _bankService = bankService;
            _accountService = accountService;
            _notifiable = notifiable;
        }

        public async Task<bool> Deposit(Guid idAccount, double amount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            var bank = _bankService.GetBankById(account.IdBank);

            if (account.Invalid && bank.Invalid) return false;

            Deposit deposit = new Deposit(amount, DateTime.Now, account, bank);
            if (DepositMade(deposit) is false) return false;

            var updatedAccount = await _accountService.UpdateAccount(account);
            if (InsertMade(updatedAccount) is false) return false;

            var bankStatement = new BankStatement(Enum.GetName(typeof(TransactionType), TransactionType.Deposit), DateTime.Now, amount, account.Balance, account.Id, account.IdOwner);
            var insertedBankStatement = await _bankStatementService.RegisterBankStatement(bankStatement);

            return (updatedAccount && insertedBankStatement);
        }

        private bool DepositMade(Deposit deposit)
        {
            var result = deposit.Execute();
            if (result <= 0)
            {
                _notifiable.AddNotification(new Notification("Deposit failed"));
                return false;
            }
            return true;
        }

        private bool InsertMade(bool updatedAccount)
        {
            if (!updatedAccount)
            {
                _notifiable.AddNotification(new Notification("Deposit failed"));
                return false;
            }
            return true;
        }
    }
}
