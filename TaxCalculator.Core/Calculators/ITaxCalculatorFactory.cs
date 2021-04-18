using System;
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
        /// <returns>
        /// A new tax calculator instance.
        /// </returns>
        /// <exception cref="InvalidOperationException">The currency \"{currency}\" is not supported.</exception>
        ITaxCalculator GetForCurrency(Currency currency);
    }
}
