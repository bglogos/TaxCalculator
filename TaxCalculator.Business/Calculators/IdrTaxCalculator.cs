using System;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Business.Calculators
{
    /// <summary>
    /// The tax calculator for Imagiaria Dolars.
    /// </summary>
    /// <seealso cref="ITaxCalculator" />
    internal class IdrTaxCalculator : ITaxCalculator
    {
        /// <inheritdoc />
        public Salary GetNetSalary(Salary grossSalary)
        {
            throw new NotImplementedException();
        }
    }
}
