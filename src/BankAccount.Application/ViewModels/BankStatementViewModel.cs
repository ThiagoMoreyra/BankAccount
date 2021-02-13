using BankAccount.Domain.BankStatements.Enum;
using System;

namespace BankAccount.Application.ViewModels
{
    public class BankStatementViewModel
    {
        public TransactionType TransactionType { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public double Amount { get; private set; }
    }
}
