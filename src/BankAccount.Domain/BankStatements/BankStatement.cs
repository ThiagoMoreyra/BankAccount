using BankAccount.Domain.Accounts;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared;
using System;

namespace BankAccount.Domain.BankStatements
{
    public class BankStatement : Entity
    {
        public BankStatement() { }
        public BankStatement(TransactionType transactionType, DateTime transactionDate, double amount, Account account, Owner owner)
        {
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            Amount = amount;
            Account = account;
            Owner = owner;
        }

        public TransactionType TransactionType { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public double Amount { get; private set; }
        public Account Account { get; private set; }
        public Owner Owner { get; private set; }
    }
}
