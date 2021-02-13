﻿using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Shared;
using BankAccount.Domain.Shared.Validations;
using System;

namespace BankAccount.Domain.Transactions
{
    public class Transaction : Entity
    {
        protected Transaction() { }
        protected Transaction(double amount, DateTime movDate)
        {
            MovDate = movDate;
            Amount = amount;

            AddNotifications(new Contract()
                            .Requires()
                            .ValidateIfLessThan(this.Amount, 0, "The Amount filed is invalid"));                            
        }

        public Guid IdAccount { get; set; }
        public Guid IdBank { get; set; }
        public double Amount { get; private set; }
        public DateTime MovDate { get; private set; }
        public Bank Bank { get; private set; }
        public Account Account { get; private set; }
    }
}
