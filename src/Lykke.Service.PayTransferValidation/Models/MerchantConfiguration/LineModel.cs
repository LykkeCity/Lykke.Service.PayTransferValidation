namespace Lykke.Service.PayTransferValidation.Models.MerchantConfiguration
{
    /// <summary>
    /// Merchant configuration line model
    /// </summary>
    public class LineModel
    {
        /// <summary>
        /// Gets or sets algorithm id
        /// </summary>
        public string AlgorithmId { get; set; }

        /// <summary>
        /// Gets or sets algorithm display name
        /// </summary>
        public string AlgorithmDisplayName { get; set; }

        /// <summary>
        /// Gets or sets algorithm input
        /// </summary>
        public string AlgorithmInput { get; set; }

        /// <summary>
        /// Gets or sets enabled flag
        /// </summary>
        public bool Enabled { get; set; }
    }
}
