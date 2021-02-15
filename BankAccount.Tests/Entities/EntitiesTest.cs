using AutoMapper;
using BankAccount.Application.UseCases.Accounts;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared.Notify;
using BankAccount.Domain.Shared.ValueObjects;
using Moq;
using System;
using Xunit;

namespace BankAccount.Tests.Entities
{
    public class EntitiesTest
    {
        [Fact]
        public void OpenAccount_Return_Account_Invalid_Negative_Numer()
        {
            var account = new Account(-1, -1);
            Assert.True(account.Invalid);
        }

        [Fact]
        public void OpenAccount_Return_Account_Valid()
        {
            var account = new Account(1234, 700.0);
            Assert.True(account.Valid);
        }

        [Fact]
        public void Bank_Return_Entity_Invalid_CompanyName_Empty()
        {
            var bank = new Bank(-1, "");
            Assert.True(bank.Invalid);
        }

        [Fact]
        public void Bank_Return_Entity_Valid()
        {
            var bank = new Bank(1234, "Test Bank");
            Assert.True(bank.Valid);
        }

        [Fact]
        public void Owner_Return_Entity_Invalid_Name_Empty()
        {
            var name = new Name(string.Empty, string.Empty);
            var cpf = new Cpf("524.705.290-00");
            var address = new Address("Rua x", "123", "x", "x", "x", "x", "x");
            var owner = new Owner(name, new DateTime(1900, 11, 10), cpf, address);

            Assert.True(owner.Invalid);
        }

        [Fact]
        public void Owner_Return_Entity_Valid()
        {
            var name = new Name("Thiago","Moreira");
            var cpf = new Cpf("524.705.290-00");
            var address = new Address("Rua x", "123", "x", "x", "x", "x", "x");
            var owner = new Owner(name, new DateTime(1900, 11, 10), cpf, address);

            Assert.True(owner.Valid);
        }

        [Fact]
        public void Return_Cpf_Invalid()
        {            
            var cpf = new Cpf("000.000.000-00");           

            Assert.False(cpf.Validate());
        }
    }
}
