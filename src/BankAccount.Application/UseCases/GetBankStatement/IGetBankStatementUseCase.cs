using BankAccount.Domain.BankStatements;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.GetBankStatement
{
    public interface IGetBankStatementUseCase
    {
        Task<IEnumerable<object>> GetBankStatement(Guid idAccount);

        decimal GetAvaliableBalance(Guid idAccount);
    }
}
