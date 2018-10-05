using System.ComponentModel.DataAnnotations;
using Lykke.Service.PayTransferValidation.Validation;
using LykkePay.Common.Validation;

namespace Lykke.Service.PayTransferValidation.Models.Validation
{
    /// <summary>
    /// Validation context model
    /// </summary>
    public class ValidationContextModel
    {
        /// <summary>
        /// Gets or sets merchant id
        /// </summary>
        [Required]
        [RowKey]
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets transfer amount
        /// </summary>
        [DecimalGreaterThanZero]
        public decimal TransferAmount { get; set; }

        /// <summary>
        /// Gets or sets expected amount
        /// </summary>
        [DecimalGreaterThanZero]
        public decimal ExpectedAmount { get; set; }

        /// <summary>
        /// Gets or sets asset id
        /// </summary>
        [Required]
        public string AssetId { get; set; }
    }
}
