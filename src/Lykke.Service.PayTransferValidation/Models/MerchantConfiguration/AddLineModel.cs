using System.ComponentModel.DataAnnotations;
using LykkePay.Common.Validation;
using Newtonsoft.Json.Linq;

namespace Lykke.Service.PayTransferValidation.Models.MerchantConfiguration
{
    /// <summary>
    /// Add merchant configuration line model
    /// </summary>
    public class AddLineModel
    {
        /// <summary>
        /// Gets or sets merchant id
        /// </summary>
        [Required]
        [RowKey]
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets rule id
        /// </summary>
        [Required]
        [RowKey]
        public string RuleId { get; set; }

        /// <summary>
        /// Gets or sets rule input
        /// </summary>
        public JObject RuleInput { get; set; }
    }
}
