namespace Lykke.Service.PayTransferValidation.Client.Models.MerchantConfiguration
{
    /// <summary>
    /// Merchant configuration line model
    /// </summary>
    public class LineModel
    {
        /// <summary>
        /// Gets or sets rule id
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// Gets or sets rule display name
        /// </summary>
        public string RuleDisplayName { get; set; }

        /// <summary>
        /// Gets or sets rule input
        /// </summary>
        public string RuleInput { get; set; }

        /// <summary>
        /// Gets or sets enabled flag
        /// </summary>
        public bool Enabled { get; set; }
    }
}
