using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Application.ViewModels
{
    public class TransactionViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public Guid IdAccount { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public double Amount { get; set; }
    }
}
