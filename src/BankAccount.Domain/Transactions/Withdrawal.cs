using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Withdrawal : Transaction
    {
        public Withdrawal(double amount, DateTime movDate)
            : base(amount, movDate) { }

        public int Execute()
        {
            return Bank.Debit(Account.Id, this.Amount);
        }
    }
}
