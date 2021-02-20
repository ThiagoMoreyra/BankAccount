using System.Threading.Tasks;

namespace BankAccount.Domain.BankStatements.Services
{
    public interface IBankStatementService
    {
        Task<bool> RegisterBankStatement(BankStatement bankStatement);
    }
}
