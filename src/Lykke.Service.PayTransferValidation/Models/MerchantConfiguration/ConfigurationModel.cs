using System.Collections.Generic;

namespace Lykke.Service.PayTransferValidation.Models.MerchantConfiguration
{
    /// <summary>
    /// Merchant configuration line model
    /// </summary>
    public class ConfigurationModel
    {
        /// <summary>
        /// Gets or sets an array of rule settings
        /// </summary>
        public IReadOnlyList<LineModel> Rules { get; set; }
    }
}
