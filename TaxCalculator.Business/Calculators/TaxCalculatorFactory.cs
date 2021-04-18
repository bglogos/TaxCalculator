using System;
using TaxCalculator.Core.Calculators;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Constants;
using TaxCalculator.Models.Enums;

namespace TaxCalculator.Business.Calculators
{
    /// <summary>
    /// Tax calculator factory methods.
    /// </summary>
    public class TaxCalculatorFactory : ITaxCalculatorFactory
    {
        /// <inheritdoc />
        public ITaxCalculator GetForCurrency(Currency currency, TaxCalculatorConfig calculatorConfigurations)
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
