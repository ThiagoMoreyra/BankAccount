using BankAccount.Domain.BankStatements.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Application.ViewModels
{
    public class BankStatementViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public TransactionType TransactionType { get; private set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime TransactionDate { get; private set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public double Amount { get; private set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public double AvaliableBalance { get; private set; }
    }
}
