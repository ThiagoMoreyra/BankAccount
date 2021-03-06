﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Application.ViewModels
{
    public class BankViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int BankCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string CompanyName { get; set; }        
    }
}
