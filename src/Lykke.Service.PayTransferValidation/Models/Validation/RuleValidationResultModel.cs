namespace Lykke.Service.PayTransferValidation.Models.Validation
{
    /// <summary>
    /// Rule validation result model
    /// </summary>
    public class RuleValidationResultModel
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
