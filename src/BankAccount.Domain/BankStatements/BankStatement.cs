using BankAccount.Domain.Accounts;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared;
using BankAccount.Domain.Shared.Validations;
using System;

namespace BankAccount.Domain.BankStatements
{
    public class BankStatement : Entity
    {
        protected BankStatement() { }
        public BankStatement(TransactionType transactionType, DateTime transactionDate, double amount, Guid idAccount, Guid idOwner)
        {
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            Amount = amount;
            IdAccount = idAccount;
            IdOwner = idOwner;
            
            AddNotifications(new Contract()
                            .Requires()
                            .ValidateMinMax(this.Amount, 5, 10, "The Amount field is invalid"));
        }

        public Guid IdAccount { get; set; }
        public Guid IdOwner { get; set; }
        public TransactionType TransactionType { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public double Amount { get; private set; }
        public Account Account { get; private set; }
        public Owner Owner { get; private set; }
    }
}
