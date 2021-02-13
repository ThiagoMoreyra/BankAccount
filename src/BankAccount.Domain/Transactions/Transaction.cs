using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Shared;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Transaction : Entity
    {
        protected Transaction() { }
        protected Transaction(double amount, DateTime movDate)
        {
            MovDate = movDate;
            Amount = amount;
        }

        public Guid IdAccount { get; set; }
        public Guid IdBank { get; set; }
        public double Amount { get; private set; }
        public DateTime MovDate { get; private set; }
        public Bank Bank { get; private set; }
        public Account Account { get; private set; }
    }
}
