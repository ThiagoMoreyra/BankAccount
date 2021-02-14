using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Application.ViewModels
{
    public class TransactionViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid IdAccount { get; private set; }        

        [Required(ErrorMessage = "The field {0} is required")]
        public double Amount { get; set; }
    }
}
