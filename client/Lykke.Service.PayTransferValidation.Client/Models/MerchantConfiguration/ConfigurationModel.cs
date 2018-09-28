using System.Collections.Generic;

namespace Lykke.Service.PayTransferValidation.Client.Models.MerchantConfiguration
{
    /// <summary>
    /// Merchant configuration line model
    /// </summary>
    public class ConfigurationModel
    {
        /// <summary>
        /// Gets or sets an array of algorithm settings
        /// </summary>
        public IReadOnlyList<LineModel> Algorithms { get; set; }
    }
}
