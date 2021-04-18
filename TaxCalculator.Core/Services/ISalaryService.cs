using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Core.Services
{
    /// <summary>
    /// Service for salary-related operations.
    /// </summary>
    public interface ISalaryService
    {
        /// <summary>
        /// Gets the net salary after subtracting all taxes.
        /// </summary>
        /// <param name="grossSalary">The gross salary.</param>
        /// <returns>The remaining net salary after taxation.</returns>
        Salary GetNetSalary(Salary grossSalary);

        /// <summary>
        /// Builds a <see cref="Salary" /> instance from given amount and currency.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>
        /// A new <see cref="Salary" /> instance.
        /// </returns>
        Salary BuildSalary(string amount, string currencyCode);
    }
}
