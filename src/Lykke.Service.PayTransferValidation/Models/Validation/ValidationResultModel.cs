using System.Collections.Generic;

namespace Lykke.Service.PayTransferValidation.Models.Validation
{
    /// <summary>
    /// Validation result model
    /// </summary>
    public class ValidationResultModel
    {
        /// <summary>
        /// Gets or sets algorithms validation result array
        /// </summary>
        public IReadOnlyList<AlgorithmValidationResultModel> Results { get; set; }
    }
}
