using System;
using TaxCalculator.Business.Calculators;
using TaxCalculator.Core.Services;
using TaxCalculator.Models.Config;
using TaxCalculator.Models.Constants;
using TaxCalculator.Models.Dtos;
using TaxCalculator.Models.Enums;

namespace TaxCalculator.Business.Services
{
    /// <summary>
    /// The default implementation of <see cref="ISalaryService"/>.
    /// </summary>
    /// <seealso cref="ISalaryService" />
    public class SalaryService : ISalaryService
    {
        private readonly AppConfig _appConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryService"/> class.
        /// </summary>
        /// <param name="appConfig">The application configuration.</param>
        public SalaryService(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        /// <inheritdoc />
        public Salary GetNetSalary(Salary grossSalary)
        {
            ITaxCalculator taxCalculator = TaxCalculatorFactory.GetForCurrency(grossSalary.Currency, _appConfig.TaxCalculatorConfig);
            return taxCalculator.GetNetSalary(grossSalary);
        }

        /// <inheritdoc />
        public Salary BuildSalary(string amount, string currencyCode)
        {
            if (decimal.TryParse(amount, out decimal salaryAmount))
            {
                if (salaryAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), Messages.SalaryCannotBeZeroOrNegative);
                }

                return new Salary
                {
                    Amount = salaryAmount,
                    Currency = GetCurrency(currencyCode)
                };
            }
            else
            {
                throw new ArgumentException(Messages.InvalidGrossSalaryFormat);
            }
        }

        private Currency GetCurrency(string currencyCode)
        {
            currencyCode = !string.IsNullOrEmpty(currencyCode) ? currencyCode : _appConfig.DefaultCurrencyCode;

            if (!Enum.TryParse(currencyCode, ignoreCase: true, out Currency currency))
            {
                throw new ArgumentException(Messages.GetInvalidCurrency(currencyCode));
            }

            return currency;
        }
    }
}
