using System;
using TaxCalculator.Core.Calculators;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Business.Calculators
{
    /// <summary>
    /// The tax calculator for Imagiaria Dolars.
    /// </summary>
    /// <seealso cref="ITaxCalculator" />
    public class IdrTaxCalculator : ITaxCalculator
    {
        private readonly IdrCalculatorConfig _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdrTaxCalculator"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public IdrTaxCalculator(IdrCalculatorConfig config)
        {
            _config = config;
        }

        /// <inheritdoc />
        public Salary GetNetSalary(Salary grossSalary)
        {
            decimal taxableAmount = Math.Max(grossSalary.Amount - _config.NoTaxationThreshold, 0);

            decimal incomeTax = taxableAmount * (_config.IncomeTaxPercent / 100M);
            decimal socialContribution = Math.Min(taxableAmount, _config.SocialContributionsThreshold) * (_config.SocialContributionsPercent / 100M);

            return new Salary
            {
                Amount = grossSalary.Amount - incomeTax - socialContribution,
                Currency = grossSalary.Currency
            };
        }
    }
}
