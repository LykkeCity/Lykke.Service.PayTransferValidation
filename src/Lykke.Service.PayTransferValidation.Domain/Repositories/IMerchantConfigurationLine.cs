namespace Lykke.Service.PayTransferValidation.Domain.Repositories
{
    public interface IMerchantConfigurationLine
    {
        string MerchantId { get; set; }

        string AlgorithmId { get; set; }

        string AlgorithmInput { get; set; }

        bool? Enabled { get; set; }
    }
}
