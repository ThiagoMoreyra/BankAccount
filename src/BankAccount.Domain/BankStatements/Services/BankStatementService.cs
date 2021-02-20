using System.Threading.Tasks;

namespace BankAccount.Domain.BankStatements.Services
{
    public class BankStatementService : IBankStatementService
    {
        private readonly IBankStatementRepository _bankStatementRepository;

        public BankStatementService(IBankStatementRepository bankStatementRepository)
        {
            _bankStatementRepository = bankStatementRepository;
        }

        public async Task<bool> RegisterBankStatement(BankStatement bankStatement)
        {         
            return await _bankStatementRepository.Add(bankStatement);            
        }        
    }
}
