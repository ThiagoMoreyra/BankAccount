using System;

namespace BankAccount.Domain.Accounts.Calculation
{
    public static class CalculationFutureValue
    {
        public static decimal GetDailyProfit(double i, double vp, double n)
        {
            i = i / 100 + 1;

            return (decimal)Math.Round(vp * (Math.Pow(i, (double)n)), 2);
        }
    }
}
