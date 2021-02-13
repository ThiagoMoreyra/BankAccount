using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace BankAccount.Application.ViewModels
{
    public class AccountViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid IdBank { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid IdOwner { get; set; }        

        [Required(ErrorMessage = "The field {0} is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int BankCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public double Balance { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime CreationDate { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
