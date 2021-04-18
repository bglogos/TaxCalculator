using System;
using FluentAssertions;
using Moq;
using TaxCalculator.Business.Services;
using TaxCalculator.Core.Calculators;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Dtos;
using TaxCalculator.Models.Enums;
using TaxCalculator.Tests.Unit.Providers;
using Xunit;

namespace TaxCalculator.Tests.Unit.Services
{
    /// <summary>
    /// The <see cref="SalaryService"/> tests.
    /// </summary>
    public class SalaryServiceTests
    {
        private readonly ITaxCalculatorFactory _taxCalculatorFactory;
        private readonly SalaryService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryServiceTests"/> class.
        /// </summary>
        public SalaryServiceTests()
        {
            _taxCalculatorFactory = Mock.Of<ITaxCalculatorFactory>();
            AppConfig appConfig = AppConfigProvider.AppConfig;

            _service = new SalaryService(_taxCalculatorFactory, appConfig);
        }

        /// <summary>
        /// GetNetSalary method should invoke the tax calculator factory.
        /// </summary>
        [Fact]
        public void GetNetSalarySouldCallTaxCalculatorFactory()
        {
            Salary grossSalary = SalaryProvider.Get();

            ITaxCalculator taxCalculator = Mock.Of<ITaxCalculator>();

            Mock.Get(_taxCalculatorFactory)
                .Setup(tcf => tcf.GetForCurrency(grossSalary.Currency))
                .Returns(taxCalculator);

            _service.GetNetSalary(grossSalary);

            Mock.Get(_taxCalculatorFactory)
                .Verify(tcf => tcf.GetForCurrency(grossSalary.Currency), Times.Once);
        }

        /// <summary>
        /// GetNetSalary method should invoke a tax calculator method.
        /// </summary>
        [Fact]
        public void GetNetSalarySouldCallTaxCalculator()
        {
            Salary grossSalary = SalaryProvider.Get();

            ITaxCalculator taxCalculator = Mock.Of<ITaxCalculator>();

            Mock.Get(_taxCalculatorFactory)
                .Setup(tcf => tcf.GetForCurrency(grossSalary.Currency))
                .Returns(taxCalculator);

            _service.GetNetSalary(grossSalary);

            Mock.Get(taxCalculator).Verify(tc => tc.GetNetSalary(grossSalary), Times.Once);
        }

        /// <summary>
        /// BuildSalary method should build a new <see cref="Salary"/> instance by given amount and currency.
        /// </summary>
        [Fact]
        public void BuildSalaryShouldBuildByGivenAmountAndCurrency()
        {
            Salary salary = SalaryProvider.Get();
            Salary result = _service.BuildSalary(salary.Amount.ToString(), salary.Currency.ToString());
            result.Should().Match<Salary>(r => r.Amount == salary.Amount && r.Currency == salary.Currency);
        }

        /// <summary>
        /// BuildSalary method should throw an exception on zero or negative salary amount.
        /// </summary>
        /// <param name="amount">The amount of the salary.</param>
        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        public void BuildSalaryShouldThrowOnZeroOrNegativeAmount(string amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.BuildSalary(amount, string.Empty));
        }

        /// <summary>
        /// BuildSalary method should throw an exception on invalid salary amount.
        /// </summary>
        /// <param name="amount">The amount of the salary.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        public void BuildSalaryShouldThrowOnNullOrInvalidAmount(string amount)
        {
            Assert.Throws<ArgumentException>(() => _service.BuildSalary(amount, string.Empty));
        }

        /// <summary>
        /// BuildSalary method should build a new <see cref="Salary" /> instance by given amount, but using the default currency.
        /// </summary>
        /// <param name="currency">The provided currency.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void BuildSalaryShouldBuildWithDefaultCurrency(string currency)
        {
            Salary salary = SalaryProvider.Get();
            Salary result = _service.BuildSalary(salary.Amount.ToString(), currency);
            result.Should().Match<Salary>(r => r.Amount == salary.Amount && r.Currency == Currency.IDR);
        }

        /// <summary>
        /// BuildSalary method should throw an exception on invalid currency.
        /// </summary>
        [Fact]
        public void BuildSalaryShouldThrowOnInvalidCurrency()
        {
            Assert.Throws<ArgumentException>(() => _service.BuildSalary("1", "bgn"));
        }
    }
}
