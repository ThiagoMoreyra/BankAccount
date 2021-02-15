using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Withdrawal : Transaction
    {
        public Withdrawal(double amount, DateTime movDate, Account account, Bank bank)
            : base(amount, movDate, account, bank) { }

        public int Execute()
        {
            return Bank.Debit(Account, this.Amount);
        }
    }
}
