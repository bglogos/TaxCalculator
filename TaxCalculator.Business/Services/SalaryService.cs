using System;
using TaxCalculator.Business.Calculators;
using TaxCalculator.Core.Services;
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
        /// <inheritdoc />
        public Salary GetNetSalary(Salary grossSalary)
        {
            ITaxCalculator taxCalculator = TaxCalculatorFactory.GetForCurrency(grossSalary.Currency);
            return taxCalculator.GetNetSalary(grossSalary);
        }

        /// <inheritdoc />
        public Salary BuildSalary(string amount, string currencyCode)
        {
            if (decimal.TryParse(amount, out decimal salaryAmount))
            {
                if (salaryAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "The provided salary cannot be zero or negative.");
                }

                Salary salary = new Salary
                {
                    Amount = salaryAmount,
                    Currency = Currency.IDR
                };

                if (!string.IsNullOrEmpty(currencyCode) && Enum.TryParse(currencyCode, ignoreCase: true, out Currency currency))
                {
                    salary.Currency = currency;
                }

                return salary;
            }
            else
            {
                throw new ArgumentException("The provided gross salary is not in valid format.");
            }
        }
    }
}
