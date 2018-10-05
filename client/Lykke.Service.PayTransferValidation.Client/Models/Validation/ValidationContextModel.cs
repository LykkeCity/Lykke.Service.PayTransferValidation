namespace Lykke.Service.PayTransferValidation.Client.Models.Validation
{
    /// <summary>
    /// Validation context model
    /// </summary>
    public class ValidationContextModel
    {
        /// <summary>
        /// Gets or sets merchant id
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets transfer amount
        /// </summary>
        public decimal TransferAmount { get; set; }

        /// <summary>
        /// Gets or sets expected amount
        /// </summary>
        public decimal ExpectedAmount { get; set; }

        /// <summary>
        /// Gets or sets asset id
        /// </summary>
        public string AssetId { get; set; }
    }
}
