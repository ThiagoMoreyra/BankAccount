using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Deposit : Transaction
    {
        public Deposit(double amount, DateTime movDate)
            : base(amount, movDate) { }

        public int Execute()
        {
            return Bank.Credit(Account.Id, this.Amount);
        }
    }
}
