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
        private readonly TaxCalculatorConfig _calculatorConfigurations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxCalculatorFactory"/> class.
        /// </summary>
        /// <param name="appConfig">The application configuration.</param>
        public TaxCalculatorFactory(AppConfig appConfig)
        {
            _calculatorConfigurations = appConfig.TaxCalculatorConfig;
        }

        /// <inheritdoc />
        public ITaxCalculator GetForCurrency(Currency currency)
        {
            switch (currency)
            {
                case Currency.IDR:
                    return new IdrTaxCalculator(_calculatorConfigurations.IdrCalculatorConfig);
                default:
                    throw new InvalidOperationException(Messages.GetNotSupportedCurrency(currency));
            }
        }
    }
}
