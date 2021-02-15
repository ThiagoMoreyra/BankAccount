using BankAccount.Domain.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Application.ViewModels
{
    public class OwnerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Number { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string ZipCode { get; set; }       
        
    }
}
