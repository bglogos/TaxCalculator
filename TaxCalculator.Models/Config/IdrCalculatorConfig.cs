namespace TaxCalculator.Models.Config
{
    /// <summary>
    /// Configuration values for the IDR tax calculator.
    /// </summary>
    public class IdrCalculatorConfig
    {
        /// <summary>
        /// Gets or sets the threshold for taxation. Amounts below that limit will not be taxed.
        /// </summary>
        /// <value>
        /// The no taxation threshold.
        /// </value>
        public decimal NoTaxationThreshold { get; set; }

        /// <summary>
        /// Gets or sets the income tax percent. Applied only to amounts over the <see cref="NoTaxationThreshold"/>.
        /// </summary>
        /// <value>
        /// The income tax percent.
        /// </value>
        public decimal IncomeTaxPercent { get; set; }

        /// <summary>
        /// Gets or sets the social contributions percent. Applied only to amounts over the <see cref="NoTaxationThreshold"/>.
        /// </summary>
        /// <value>
        /// The social contributions percent.
        /// </value>
        public decimal SocialContributionsPercent { get; set; }

        /// <summary>
        /// Gets or sets the social contributions threshold.
        /// The upper limit of the amount the <see cref="SocialContributionsThreshold"/> can be applied on.
        /// </summary>
        /// <value>
        /// The social contributions threshold.
        /// </value>
        public decimal SocialContributionsThreshold { get; set; }
    }
}
