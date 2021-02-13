using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Pay : Transaction
    {
        public Pay(double amount, DateTime movDate, Account account, Bank bank)
            : base(amount, movDate, account, bank) { }

        public int Execute()
        {
            return Bank.Pay(Account.Id, this.Amount);
        }
    }
}
