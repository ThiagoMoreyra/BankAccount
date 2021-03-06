﻿using System;
using System.Threading.Tasks;

namespace BankAccount.Domain.Banks.Services
{
    public interface IBankService
    {
        Task<bool> RegisterBank(Bank bank);
        Bank GetBankById(Guid id);
    }
}
