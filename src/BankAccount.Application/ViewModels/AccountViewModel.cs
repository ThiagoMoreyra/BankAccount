using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
