namespace BankAccount.Domain.BankStatements
{
    public class BankStatementService : IBankStatementService
    {
        private readonly IBankStatementRepository _bankStatementRepository;

        public BankStatementService(IBankStatementRepository bankStatementRepository)
        {
            _bankStatementRepository = bankStatementRepository;
        }

        public void RegisterBankStatement(BankStatement bankStatement)
        {
            _bankStatementRepository.Add(bankStatement);
        }        
    }
}
