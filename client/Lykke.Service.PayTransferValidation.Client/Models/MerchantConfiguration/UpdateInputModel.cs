using Newtonsoft.Json.Linq;

namespace Lykke.Service.PayTransferValidation.Client.Models.MerchantConfiguration
{
    /// <summary>
    /// Update merchant configuration line model
    /// </summary>
    public class UpdateInputModel
    {
        /// <summary>
        /// Gets or sets merchant id
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets algorithm id
        /// </summary>
        public string AlgorithmId { get; set; }

        /// <summary>
        /// Gets or sets algorithm input
        /// </summary>
        public JObject AlgorithmInput { get; set; }
    }
}
