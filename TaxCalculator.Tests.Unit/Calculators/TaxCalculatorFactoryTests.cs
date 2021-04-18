using System;
using FluentAssertions;
using TaxCalculator.Business.Calculators;
using TaxCalculator.Core.Calculators;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Enums;
using TaxCalculator.Tests.Unit.Providers;
using Xunit;

namespace TaxCalculator.Tests.Unit.Calculators
{
    /// <summary>
    /// The <see cref="TaxCalculatorFactory"/> unit tests.
    /// </summary>
    public class TaxCalculatorFactoryTests
    {
        private readonly TaxCalculatorFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxCalculatorFactoryTests"/> class.
        /// </summary>
        public TaxCalculatorFactoryTests()
        {
            AppConfig appConfig = AppConfigProvider.AppConfig;
            _factory = new TaxCalculatorFactory(appConfig);
        }

        /// <summary>
        /// GetForCurrency method should return the calculator for IDR.
        /// </summary>
        [Fact]
        public void GetForCurrencyShouldReturnIdrCalculator()
        {
            ITaxCalculator calculator = _factory.GetForCurrency(Currency.IDR);
            calculator.Should().BeOfType<IdrTaxCalculator>();
        }

        /// <summary>
        /// GetForCurrency method should throw an exception when the currency is not supported.
        /// </summary>
        [Fact]
        public void GetForCurrencyShouldThrowOnUnsupportedCurrencies()
        {
            Assert.Throws<InvalidOperationException>(() => _factory.GetForCurrency(Currency.USD));
        }
    }
}
