using TaxCalculator.Models.Enums;

namespace TaxCalculator.Models.Dtos
{
    /// <summary>
    /// Salary data.
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// Gets or sets the amount of the salary.
        /// </summary>
        /// <value>
        /// The amount as decimal number.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency as <see cref="Enums.Currency"/> value.
        /// </value>
        public Currency Currency { get; set; }
    }
}
