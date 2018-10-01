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
        /// Gets or sets rule id
        /// </summary>
        [Required]
        [RowKey]
        public string RuleId { get; set; }

        /// <summary>
        /// Gets or sets rule input
        /// </summary>
        [Required]
        public JObject RuleInput { get; set; }
    }
}
