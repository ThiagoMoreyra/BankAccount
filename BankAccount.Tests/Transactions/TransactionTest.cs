using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared.ValueObjects;
using BankAccount.Domain.Transactions;
using System;
using Xunit;

namespace BankAccount.Tests.Transactions
{
    public class TransactionTest
    {
        private Withdrawal withdrawal;
        private Deposit deposit;
        private readonly Account account;
        private readonly Bank bank;
        public TransactionTest()
        {
            var name = new Name("Teste 1", "teste");
            var cpf = new Cpf("524.705.290-00");
            var address = new Address("Rua x", "123", "x", "x", "x", "x", "x");
            var owner = new Owner(name, new DateTime(1900, 11, 10), cpf, address);
            account = new Account(12345, 123.0);
            bank = new Bank(123, "Bradesco");
            bank.Accounts.Add(account);
        }

        [Fact]
        public void MakeWithdraw_Return_Withdraw_Realized()
        {
            withdrawal = new Withdrawal(12.0, DateTime.Now, account, bank);

            int result = withdrawal.Execute();

            Assert.Equal(1, result);
        }

        [Fact]
        public void MakeWithdraw_Return_Withdraw_Not_Realized()
        {

            withdrawal = new Withdrawal(500.0, DateTime.Now, account, bank);

            int result = withdrawal.Execute();

            Assert.Equal(0, result);
        }

        [Fact]
        public void MakeWithdraw_Return_AvaliableBalance_Valid()
        {

            withdrawal = new Withdrawal(20.0, DateTime.Now, account, bank);

            var result = withdrawal.Execute();

            Assert.Equal(103, bank.GetAvaliableBalance(account.Id));
        }

        [Fact]
        public void MakeDeposit_Return_AvaliableBalance_Valid()
        {

            deposit = new Deposit(20.0, DateTime.Now, account, bank);

            var result = deposit.Execute();

            Assert.Equal(143, bank.GetAvaliableBalance(account.Id));
        }
    }
}
