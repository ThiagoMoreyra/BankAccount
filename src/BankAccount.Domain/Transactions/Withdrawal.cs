using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;

namespace BankAccount.Domain.Transactions
{
    public class Withdrawal : Transaction
    {
        public Withdrawal(double amount, Account account, Bank bank)
            : base(bank, account)
        {
            Amount = amount;
        }

        public double Amount { get; private set; }

        public int Execute()
        {
            return Bank.Debit(Account.Id, this.Amount);
        }
    }
}
