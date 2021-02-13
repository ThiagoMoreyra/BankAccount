﻿using BankAccount.Domain.Accounts;
using BankAccount.Domain.Shared;
using BankAccount.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace BankAccount.Domain.Banks
{
    public class Bank : Entity
    {
        protected Bank() { }
        public Bank(int bankCode, Account account, string companyName)
        {
            BankCode = bankCode;
            CompanyName = companyName;
            this.AuthenticatedUser = true;
            Accounts = new List<Account>();
            Accounts.Add(account);
        }

        public int BankCode { get; private set; }
        public string CompanyName { get; private set; }
        public bool AuthenticatedUser { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }

        public int Credit(Guid accountId, double amount)
        {
            if (!UserIsAuthenticated())
                return 0;

            var account = GetAccount(accountId);
            return account.MakeDeposit(amount);
        }

        public int Debit(Guid accountId, double amount)
        {
            if (!UserIsAuthenticated())
                return 0;

            var account = GetAccount(accountId);
            return account.MakeWithdraw(amount);
        }

        public int Pay(Guid accountId, double amount)
        {
            if (!UserIsAuthenticated())
                return 0;

            var account = GetAccount(accountId);
            return account.MakePay(amount);
        }

        public void SetAuthenticatedUser(bool active)
        {
            this.AuthenticatedUser = active;
        }

        public double GetAvaliableBalance(Guid accountId)
        {
            if (!UserIsAuthenticated())
                return 0;

            var account = GetAccount(accountId);
            return account.GetAvaliableBalance();
        }

        private bool UserIsAuthenticated()
        {
            return AuthenticatedUser;
        }

        private Account GetAccount(Guid accountId)
        {
            return Accounts.Find(x => x.Id == accountId);
        }



    }
}