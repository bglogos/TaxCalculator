using System;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Enums;

namespace TaxCalculator.Core.Calculators
{
    /// <summary>
    /// Factory for building tax calculators.
    /// </summary>
    public interface ITaxCalculatorFactory
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
        ITaxCalculator GetForCurrency(Currency currency, TaxCalculatorConfig calculatorConfigurations);
    }
}
