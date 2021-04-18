using TaxCalculator.Models.Dtos;
using TaxCalculator.Models.Enums;

namespace TaxCalculator.Models.Constants
{
    /// <summary>
    /// The text messages displayed in the application.
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// Application's help menu hint for entering the gross amount.
        /// </summary>
        public const string GrossAmountHint = "The amount of the gross salary.";

        /// <summary>
        /// Application's template for entering the gross amount.
        /// </summary>
        public const string GrossAmountOption = "-g | --gross <amount>";

        /// <summary>
        /// Application's template for entering the currency.
        /// </summary>
        public const string CurrencyOption = "-c | --currency <currencyCode>";

        /// <summary>
        /// Application's template for showing the help menu.
        /// </summary>
        public const string HelpOption = "-? | -h | --help";

        /// <summary>
        /// Salary amount validation message.
        /// </summary>
        public const string SalaryCannotBeZeroOrNegative = "The provided salary cannot be zero or negative.";

        /// <summary>
        /// Salary format validation message.
        /// </summary>
        public const string InvalidGrossSalaryFormat = "The provided gross salary is not in valid format.";

        private const string CurrencyHintTemplate = "The currency of the salary. If not provided, the default value is \"{0}\"";

        private const string ResultTemplate = "Net salary: {0} {1}";

        private const string InvalidCurrencyTemplate = "The provided currency \"{0}\" is invalid.";

        private const string NotSupportedCurrencyTemplate = "The currency \"{0}\" is not supported.";

        /// <summary>
        /// Gets the application's help menu hint for entering the currency.
        /// </summary>
        /// <param name="defaultCurrency">The default currency as configured.</param>
        /// <returns>The full hint.</returns>
        public static string GetCurrencyHint(string defaultCurrency) =>
            string.Format(CurrencyHintTemplate, defaultCurrency);

        /// <summary>
        /// Gets the application's result message.
        /// </summary>
        /// <param name="salary">The net salary object.</param>
        /// <returns>The full result message.</returns>
        public static string GetResult(Salary salary) =>
            string.Format(ResultTemplate, salary.Amount, salary.Currency);

        /// <summary>
        /// Gets the invalid currency error message.
        /// </summary>
        /// <param name="currencyCode">The provided currency.</param>
        /// <returns>The full error message.</returns>
        public static string GetInvalidCurrency(string currencyCode) =>
            string.Format(InvalidCurrencyTemplate, currencyCode);

        /// <summary>
        /// Gets the not supported currency error message.
        /// </summary>
        /// <param name="currency">The provided currency.</param>
        /// <returns>The full error message.</returns>
        public static string GetNotSupportedCurrency(Currency currency) =>
            string.Format(NotSupportedCurrencyTemplate, currency);
    }
}
