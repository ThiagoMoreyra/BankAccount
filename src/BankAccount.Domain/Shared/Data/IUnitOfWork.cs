using System.Threading.Tasks;

namespace BankAccount.Domain.Shared.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
