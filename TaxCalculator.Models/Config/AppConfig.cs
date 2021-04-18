namespace TaxCalculator.Models.Config
{
    /// <summary>
    /// The application's configuration.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets the default currency code.
        /// </summary>
        /// <value>
        /// The default currency code.
        /// </value>
        public string DefaultCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the tax calculator configurations.
        /// </summary>
        /// <value>
        /// The tax calculator configuration.
        /// </value>
        public TaxCalculatorConfig TaxCalculatorConfig { get; set; }
    }
}
