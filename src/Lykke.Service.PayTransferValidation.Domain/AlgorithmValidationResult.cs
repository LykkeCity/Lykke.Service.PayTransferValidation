namespace Lykke.Service.PayTransferValidation.Domain
{
    public class AlgorithmValidationResult
    {
        private string _error;

        public string DisplayName { get; set; }
        public bool IsSuccess { get; set; }

        public string Error
        {
            get => _error;

            set
            {
                _error = value;
                IsSuccess = string.IsNullOrEmpty(_error);
            }
        }
    }
}
