using System.Threading.Tasks;

namespace BankAccount.Domain.BankStatements
{
    public interface IBankStatementService
    {
        Task<bool> RegisterBankStatement(BankStatement bankStatement);
    }
}
