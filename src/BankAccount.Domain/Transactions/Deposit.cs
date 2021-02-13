using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;

namespace BankAccount.Domain.Transactions
{
    public class Deposit : Transaction
    {
        public Deposit(double amount, Account account, Bank bank)
            : base(bank, account)
        {
            Amount = amount;                    
        }

        public double Amount { get; private set; }                
        public int Execute()
        {
            return Bank.Credit(Account.Id, this.Amount);
        }
    }
}
