using BankAccount.Application.UseCases.GetAccount;
using BankAccount.Domain.BankStatements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.GetBankStatement
{
    public class GetBankStatementUseCase : IGetBankStatementUseCase
    {
        private readonly IBankStatementRepository _bankStatementRepository;
        
        public GetBankStatementUseCase(IBankStatementRepository bankStatementRepository)
        {
            _bankStatementRepository = bankStatementRepository;            
        }

        public async Task<IEnumerable<object>> GetBankStatement(Guid idAccount)
        {
            List<object> list = new List<object>();
            var bankStatements = await _bankStatementRepository.Find(idAccount);
            foreach (var item in bankStatements)
            {
                list.Add(new
                {
                    Amount = item.Amount.ToString("C", CultureInfo.CurrentCulture),
                    Transaction = item.TransactionType,
                    Date = item.TransactionDate.ToString("dd/MM/yyyy"),
                    AvaliableBalance = item.AvaliableBalance.ToString("C", CultureInfo.CurrentCulture),
                });
            };

            return list;
        }

        public decimal GetAvaliableBalance(Guid idAccount)
        {
            return (decimal)_bankStatementRepository.FindByIdAccount(idAccount).Result.AvaliableBalance;
        }
    }
}

