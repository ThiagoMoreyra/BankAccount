﻿using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.BankStatements.Enum;
using BankAccount.Domain.Transactions;
using System;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Withdrawals
{
    public class WithdrawalUseCase : IWithdrawalUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IBankService _bankService;
        private readonly IAccountService _accountService;

        public WithdrawalUseCase(IBankStatementService bankStatementService, IBankService bankService, IAccountService accountService)
        {
            _bankStatementService = bankStatementService;
            _bankService = bankService;
            _accountService = accountService;
        }

        public async Task<bool> Withdrawal(Guid idAccount, double amount)
        {
            var account = _accountService.GetAccountById(idAccount).Result;
            var bank = _bankService.GetBankById(account.IdBank);

            if (account.Invalid && bank.Invalid) return false;

            Withdrawal withdrawal = new Withdrawal(amount, DateTime.Now, account, bank);
            var updatedAccount = false;
            var insertedBankStatement = false;

            var result = withdrawal.Execute();
            if (result > 0)
            {
                updatedAccount = await _accountService.UpdateAccount(account);
                if (updatedAccount)
                {
                    var bankStatement = new BankStatement(TransactionType.Withdrawal, DateTime.Now, amount, account.Id, account.IdOwner);
                    insertedBankStatement = await _bankStatementService.RegisterBankStatement(bankStatement);
                }
            }

            return (updatedAccount && insertedBankStatement);
        }
    }
}
