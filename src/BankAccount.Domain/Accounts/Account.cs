using BankAccount.Domain.Accounts.Calculation;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared;
using BankAccount.Domain.Shared.Validations;
using BankAccount.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.Accounts
{
    public class Account : Entity
    {
        protected Account() { }
        public Account(int number, double balance)
        {
            Number = number;
            Balance = balance;            
            CreationDate = DateTime.Now;

            AddNotifications(new Contract()
                            .Requires()
                            .ValidateMinMax(this.BankCode, 5, 10, "The BankCode filed is invalid")
                            .ValidateIfLessThan(this.BankCode, 4, "The BankCode filed is invalid")
                            .ValidateIfLessThan(this.Number, 0, "The Number filed is invalid"));
        }

        public Guid IdBank { get; set; }
        public Guid IdOwner { get; set; }
        public int Number { get; private set; }
        public int BankCode { get; private set; }
        public double Balance { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Owner Owner { get; private set; }
        public Bank Bank { get; set; }
        public List<Transaction> Transactions { get; set; }

        public int MakeDeposit(double amount)
        {
            this.Balance += amount;
            return 1;
        }

        public int MakeWithdraw(double amount)
        {
            if (amount > this.Balance)
                return 0;

            this.Balance = this.Balance - amount;
            return 1;
        }

        public int MakePay(double amount)
        {
            var result = MakeWithdraw(amount);
            return result;
        }

        public double GetAvaliableBalance()
        {
            return this.Balance;
        }

        public decimal GetAvaliableDailyProfitBalance(double fee)
        {
            var totalDays = CreationDate.Date.Subtract(DateTime.Now.Date).TotalDays;
            return CalculationFutureValue.GetDailyProfit(fee, this.Balance, totalDays);
        }
    }
}
