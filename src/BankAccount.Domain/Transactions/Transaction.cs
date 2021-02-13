using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Shared;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Transaction : Entity
    {
        protected Transaction() { }
        protected Transaction(Bank bank, Account account)
        {
            Bank = bank;
            Account = account;
        }

        public Guid IdAccount { get; private set; }
        public Guid IdBank { get; private set; }
        public Bank Bank { get; private set; }
        public Account Account { get; private set; }        
    }
}
