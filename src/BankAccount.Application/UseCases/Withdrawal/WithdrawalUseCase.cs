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

namespace BankAccount.Application.UseCases.Withdrawals
{
    public class WithdrawalUseCase : IWithdrawalUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IBankService _bankService;
        private readonly IAccountService _accountService;
        private readonly INotifiable _notifiable;

        public WithdrawalUseCase(IBankStatementService bankStatementService, IBankService bankService, IAccountService accountService, INotifiable notifiable)
        {
            _bankStatementService = bankStatementService;
            _bankService = bankService;
            _accountService = accountService;
            _notifiable = notifiable;
        }

        public async Task<bool> Withdrawal(Guid idAccount, double amount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            var bank = _bankService.GetBankById(account.IdBank);

            if (account.Invalid && bank.Invalid) return false;

            Withdrawal withdrawal = new Withdrawal(amount, DateTime.Now, account, bank);

            if (WithdrawalMade(withdrawal) is false) return false;

            var updatedAccount = await _accountService.UpdateAccount(account);
            if (UpdateMade(updatedAccount) is false) return false;    

            var bankStatement = new BankStatement(Enum.GetName(typeof(TransactionType), TransactionType.Withdrawal), DateTime.Now, amount, account.Balance, account.Id, account.IdOwner);
            var insertedBankStatement = await _bankStatementService.RegisterBankStatement(bankStatement);

            return (updatedAccount && insertedBankStatement);
        }

        private bool WithdrawalMade(Withdrawal withdrawal)
        {
            var result = withdrawal.Execute();
            if (result <= 0)
            {
                _notifiable.AddNotification(new Notification("Failed to withdraw"));
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
