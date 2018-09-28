namespace Lykke.Service.PayTransferValidation.Domain
{
    public class AlgorithmValidationResult
    {
        public string DisplayName { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }
}
