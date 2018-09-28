namespace Lykke.Service.PayTransferValidation.Models.Validation
{
    /// <summary>
    /// Algorithm validation result model
    /// </summary>
    public class AlgorithmValidationResultModel
    {
        /// <summary>
        /// Gets or sets rule name
        /// </summary>
        public string Rule { get; set; }

        /// <summary>
        /// Gets or sets success flag
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets error message
        /// </summary>
        public string Error { get; set; }
    }
}
