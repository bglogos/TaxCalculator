using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Core.Calculators
{
    /// <summary>
    /// Tax calculation methods.
    /// </summary>
    public interface ITaxCalculator
    {
        /// <summary>
        /// Gets the net salary.
        /// </summary>
        /// <param name="grossSalary">The gross salary.</param>
        /// <returns>A new <see cref="Salary"/> instance with the net amount.</returns>
        Salary GetNetSalary(Salary grossSalary);
    }
}
