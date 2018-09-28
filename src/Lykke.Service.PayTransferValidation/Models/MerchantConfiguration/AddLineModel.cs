using System.ComponentModel.DataAnnotations;
using LykkePay.Common.Validation;

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
        /// Gets or sets algorithm id
        /// </summary>
        [Required]
        [RowKey]
        public string AlgorithmId { get; set; }

        /// <summary>
        /// Gets or sets algorithm input
        /// </summary>
        public string AlgorithmInput { get; set; }
    }
}
