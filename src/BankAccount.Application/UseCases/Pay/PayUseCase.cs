using BankAccount.Domain.Accounts;
using BankAccount.Domain.Accounts.Services;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Banks.Services;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.BankStatements.Services;
using BankAccount.Domain.Shared.Notify;
using BankAccount.Domain.Transactions;
using System;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Pays
{
    public class PayUseCase : IPayUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IBankService _bankService;
        private readonly IAccountService _accountService;
        private readonly INotifiable _notifiable;

        public PayUseCase(IBankStatementService bankStatementService, IBankService bankService, IAccountService accountService, INotifiable notifiable)
        {
            _bankStatementService = bankStatementService;
            _bankService = bankService;
            _accountService = accountService;
            _notifiable = notifiable;
        }

        public async Task<bool> Pay(Guid idAccount, double amount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            var bank = _bankService.GetBankById(account.IdBank);

            if (account.Invalid && bank.Invalid) return false;

            Pay pay = new Pay(amount, DateTime.Now, account, bank);

            if (PayMade(pay) is false) return false;               

            var updatedAccount = await _accountService.UpdateAccount(account);
            if (UpdateMade(updatedAccount) is false) return false;      

            var bankStatement = new BankStatement(Enum.GetName(typeof(TransactionType), TransactionType.Pay), DateTime.Now, amount, account.Balance, account.Id, account.IdOwner);
            var insertedBankStatement = await _bankStatementService.RegisterBankStatement(bankStatement);

            return (updatedAccount && insertedBankStatement);
        }

        private bool PayMade(Pay pay)
        {
            var result = pay.Execute();
            if (result <= 0)
            {
                _notifiable.AddNotification(new Notification("Payment failed"));
                return false;
            }
            return true;
        }

        private bool UpdateMade(bool updatedAccount)
        {
            if (!updatedAccount)
            {
                _notifiable.AddNotification(new Notification("Failed to withdraw"));
                return false;
            }
            return true;
        }
    }
}
