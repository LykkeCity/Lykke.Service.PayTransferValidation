namespace Lykke.Service.PayTransferValidation.Domain.Repositories
{
    public class MerchantConfigurationLine : IMerchantConfigurationLine
    {
        public string MerchantId { get; set; }
        public string AlgorithmId { get; set; }
        public string AlgorithmInput { get; set; }
        public bool? Enabled { get; set; }
    }
}
