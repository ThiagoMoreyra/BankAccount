using System;

namespace BankAccount.Domain.Banks
{
    public interface IBankService
    {
        void RegisterBank(Bank bank);
        Bank GetBankById(Guid id);
    }
}
