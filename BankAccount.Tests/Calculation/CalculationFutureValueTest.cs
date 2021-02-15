using BankAccount.Domain.Accounts.Calculation;
using Xunit;

namespace BankAccount.Tests.Calculation
{
    public class CalculationFutureValueTest
    {
        [Fact]
        public void Return_Calc_Daily_Profit_Valid()
        {
            var result = CalculationFutureValue.GetDailyProfit(0.10, 7800.0, 35);
            Assert.Equal(8077.69M, result);
        }

        [Fact]
        public void Return_Calc_Daily_Profit_InValid()
        {
            var result = CalculationFutureValue.GetDailyProfit(0.10, 5800.0, 35);
            Assert.NotEqual(8077.69M, result);
        }
    }
}
