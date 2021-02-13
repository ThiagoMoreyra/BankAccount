namespace BankAccount.Domain.Accounts
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void RegisterAccount(Account account)
        {
            _accountRepository.Add(account);
        }

        public decimal GetAvaliableBalance(double fee, Account account)
        {
            return account.GetAvaliableDailyProfitBalance(fee);
        }
    }
}
