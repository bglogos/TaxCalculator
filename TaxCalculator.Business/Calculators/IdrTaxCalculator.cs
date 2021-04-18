using System;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Business.Calculators
{
    /// <summary>
    /// The tax calculator for Imagiaria Dolars.
    /// </summary>
    /// <seealso cref="ITaxCalculator" />
    internal class IdrTaxCalculator : ITaxCalculator
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
            decimal taxableAmount = grossSalary.Amount - _config.NoTaxationThreshold;

            Salary netSalary = new Salary
            {
                Amount = grossSalary.Amount,
                Currency = grossSalary.Currency
            };

            if (taxableAmount <= 0)
            {
                return netSalary;
            }

            decimal incomeTax = taxableAmount * (_config.IncomeTaxPercent / 100M);
            decimal socialContribution = Math.Min(taxableAmount, _config.SocialContributionsThreshold) * (_config.SocialContributionsPercent / 100M);

            netSalary.Amount -= incomeTax + socialContribution;

            return netSalary;
        }
    }
}
