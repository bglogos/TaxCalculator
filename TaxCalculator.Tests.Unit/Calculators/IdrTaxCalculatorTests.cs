using FluentAssertions;
using TaxCalculator.Business.Calculators;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Dtos;
using TaxCalculator.Models.Enums;
using TaxCalculator.Tests.Unit.Providers;
using Xunit;

namespace TaxCalculator.Tests.Unit.Calculators
{
    /// <summary>
    /// The <see cref="IdrTaxCalculator"/> unit tests.
    /// </summary>
    public class IdrTaxCalculatorTests
    {
        private readonly IdrCalculatorConfig _config;
        private readonly IdrTaxCalculator _calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdrTaxCalculatorTests"/> class.
        /// </summary>
        public IdrTaxCalculatorTests()
        {
            _config = AppConfigProvider.AppConfig.TaxCalculatorConfig.IdrCalculatorConfig;
            _calculator = new IdrTaxCalculator(_config);
        }

        /// <summary>
        /// GetNetSalary method should calculate the taxes for salaries under the no taxation threshold.
        /// </summary>
        [Fact]
        public void GetNetSalaryShouldCalculateWithSalaryUnderNoTaxationThreshold()
        {
            decimal grossSalaryAmount = _config.NoTaxationThreshold / 2M;

            Salary grossSalary = SalaryProvider.Get(grossSalaryAmount, Currency.IDR);
            Salary netSalary = _calculator.GetNetSalary(grossSalary);

            netSalary.Amount.Should().Be(grossSalaryAmount);
        }

        /// <summary>
        /// GetNetSalary method should calculate the taxes for salaries above the no taxation threshold, but under the social contribution threshold.
        /// </summary>
        [Fact]
        public void GetNetSalaryShouldCalculateWithSalaryAboveNoTaxationThresholdAndUnderSocialContributionsThreshold()
        {
            decimal grossSalaryAmount = _config.NoTaxationThreshold + (_config.SocialContributionsThreshold / 2M);

            Salary grossSalary = SalaryProvider.Get(grossSalaryAmount, Currency.IDR);
            Salary netSalary = _calculator.GetNetSalary(grossSalary);

            decimal taxableAmount = grossSalary.Amount - _config.NoTaxationThreshold;
            decimal expectedNetAmount =
                grossSalary.Amount -
                (taxableAmount * (_config.IncomeTaxPercent / 100M)) -
                (taxableAmount * (_config.SocialContributionsPercent / 100M));

            netSalary.Amount.Should().Be(expectedNetAmount);
        }

        /// <summary>
        /// GetNetSalary method should calculate the taxes for salaries above the social contribution threshold.
        /// </summary>
        [Fact]
        public void GetNetSalaryShouldCalculateWithSalaryAboveSocialContributionsThreshold()
        {
            decimal grossSalaryAmount = _config.NoTaxationThreshold + (_config.SocialContributionsThreshold * 2M);

            Salary grossSalary = SalaryProvider.Get(grossSalaryAmount, Currency.IDR);
            Salary netSalary = _calculator.GetNetSalary(grossSalary);

            decimal taxableAmount = grossSalary.Amount - _config.NoTaxationThreshold;
            decimal expectedNetAmount =
                grossSalary.Amount -
                (taxableAmount * (_config.IncomeTaxPercent / 100M)) -
                (_config.SocialContributionsThreshold * (_config.SocialContributionsPercent / 100M));

            netSalary.Amount.Should().Be(expectedNetAmount);
        }
    }
}
