using BankAccount.Domain.Accounts;
using BankAccount.Domain.Shared;
using BankAccount.Domain.Shared.ValueObjects;
using System;

namespace BankAccount.Domain.Clients
{
    public class Owner : Entity
    {
        protected Owner() { }
        public Owner(Name name, DateTime birthDay, Cpf cpf, Address address)
        {
            Name = name;
            BirthDay = birthDay;
            Cpf = cpf;            
            Address = address;

            AddNotifications(name, cpf, address);
        }

        public Guid IdAccount { get; set; }        
        public Name Name { get; private set; }
        public DateTime BirthDay { get; private set; }
        public Cpf Cpf { get; private set; }
        public Account Account { get; private set; }
        public Address Address { get; private set; }

        public bool CpfIsValid()
        {
            return Cpf.Validate();
        }
    }
}
