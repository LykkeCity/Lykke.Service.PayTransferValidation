using System.ComponentModel.DataAnnotations;
using LykkePay.Common.Validation;
using Newtonsoft.Json.Linq;

namespace Lykke.Service.PayTransferValidation.Models.MerchantConfiguration
{
    /// <summary>
    /// Update merchant configuration line model
    /// </summary>
    public class UpdateInputModel
    {
        /// <summary>
        /// Gets or sets merchant id
        /// </summary>
        [Required]
        [RowKey]
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets algorithm id
        /// </summary>
        [Required]
        [RowKey]
        public string AlgorithmId { get; set; }

        /// <summary>
        /// Gets or sets algorithm input
        /// </summary>
        [Required]
        public JObject AlgorithmInput { get; set; }
    }
}
