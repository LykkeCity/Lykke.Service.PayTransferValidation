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
        /// Gets or sets rule id
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// Gets or sets rule input
        /// </summary>
        public JObject RuleInput { get; set; }
    }
}
