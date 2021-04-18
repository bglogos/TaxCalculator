using TaxCalculator.Models.Dtos;
using TaxCalculator.Models.Enums;

namespace TaxCalculator.Tests.Unit.Providers
{
    /// <summary>
    /// Provides <see cref="Salary"/> instances.
    /// </summary>
    public static class SalaryProvider
    {
        /// <summary>
        /// Gets a <see cref="Salary"/> object of 10 IDR.
        /// </summary>
        /// <returns>A new <see cref="Salary"/> instance.</returns>
        public static Salary Get() =>
            Get(10M, Currency.IDR);

        /// <summary>
        /// Gets a <see cref="Salary"/> object with specified amount and currency.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        /// <returns>A new <see cref="Salary"/> instance.</returns>
        public static Salary Get(decimal amount, Currency currency) =>
            new Salary
            {
                Amount = amount,
                Currency = currency
            };
    }
}
