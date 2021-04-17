using System;
using TaxCalculator.Models.Enums;

namespace TaxCalculator.Business.Calculators
{
    /// <summary>
    /// Tax calculator factory methods.
    /// </summary>
    internal static class TaxCalculatorFactory
    {
        /// <summary>
        /// Gets the tax calculator for the given currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>A new tax calculator instance.</returns>
        public static ITaxCalculator GetForCurrency(Currency currency)
        {
            switch (currency)
            {
                case Currency.IDR:
                    return new IdrTaxCalculator();
                default:
                    throw new InvalidOperationException($"The currency {currency} is not supported.");
            }
        }
    }
}
