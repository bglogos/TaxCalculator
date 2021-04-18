using System;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Constants;
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
        /// <param name="calculatorConfigurations">The tax calculator configurations.</param>
        /// <returns>
        /// A new tax calculator instance.
        /// </returns>
        /// <exception cref="InvalidOperationException">The currency \"{currency}\" is not supported.</exception>
        public static ITaxCalculator GetForCurrency(Currency currency, TaxCalculatorConfig calculatorConfigurations)
        {
            switch (currency)
            {
                case Currency.IDR:
                    return new IdrTaxCalculator(calculatorConfigurations.IdrCalculatorConfig);
                default:
                    throw new InvalidOperationException(Messages.GetNotSupportedCurrency(currency));
            }
        }
    }
}
