using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Pay : Transaction
    {
        public Pay(double amount, Account account, Bank bank)
            : base(bank,account)
        {
            Amount = amount;            
        }
        public double Amount { get; private set; }        
        public int Execute()
        {
            return Bank.Pay(Account.Id, this.Amount);
        }
    }
}
