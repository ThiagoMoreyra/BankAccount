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
        public BankStatement(string transactionType, DateTime transactionDate, double amount, double avaliableBalance, Guid idAccount, Guid idOwner)
        {
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            Amount = amount;
            AvaliableBalance = avaliableBalance;
            IdAccount = idAccount;
            IdOwner = idOwner;

            AddNotifications(new Contract()
                            .Requires()
                            .ValidateIfLessThan(this.Amount, 0, "The Amount field is invalid"));
        }

        public Guid IdAccount { get; set; }
        public Guid IdOwner { get; set; }
        public string TransactionType { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public double Amount { get; private set; }
        public double AvaliableBalance { get; private set; }
        public Account Account { get; private set; }
        public Owner Owner { get; private set; }
    }
}
