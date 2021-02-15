using AspNetCoreRateLimit;
using BankAccount.Application.UseCases.Accounts;
using BankAccount.Application.UseCases.Banks;
using BankAccount.Application.UseCases.Deposits;
using BankAccount.Application.UseCases.GetAccount;
using BankAccount.Application.UseCases.GetBankStatement;
using BankAccount.Application.UseCases.Pays;
using BankAccount.Application.UseCases.RegisterBankStatement;
using BankAccount.Application.UseCases.RegisterOwner;
using BankAccount.Application.UseCases.Withdrawals;
using BankAccount.Data.Context;
using BankAccount.Data.Repositories;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Owners;
using BankAccount.Domain.Shared.Notify;
using BankAccount.Domain.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BankAccount.Api.Configuration
{
    public static class InjectionConfigurationExtension
    {
        public static void InjectionConfigurationServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger<>), (typeof(Logger<>)));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<BankAccountContext>();

            //Services
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IBankStatementService, BankStatementService>();
            services.AddScoped<ITransactionService, TransactionService>();

            //Repository
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IBankStatementRepository, BankStatementRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();


            //UseCase
            services.AddScoped<IDepositUseCase, DepositUseCase>();
            services.AddScoped<IGetAccountUseCase, GetAccountUseCase>();
            services.AddScoped<IOpenAccountUseCase, OpenAccountUseCase>();
            services.AddScoped<IPayUseCase, PayUseCase>();
            services.AddScoped<IRegisterBankUseCase, RegisterBankUseCase>();
            services.AddScoped<IRegisterBankStatementUseCase, RegisterBankStatementUseCase>();
            services.AddScoped<IRegisterOwnerUseCase, RegisterOwnerUseCase>();
            services.AddScoped<IWithdrawalUseCase, WithdrawalUseCase>();
            services.AddScoped<IGetBankStatementUseCase, GetBankStatementUseCase>();

            //Notification
            services.AddScoped<INotifiable, Notifiable>();

            //Security
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
