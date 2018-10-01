namespace Lykke.Service.PayTransferValidation.Domain.Repositories
{
    public interface IMerchantConfigurationLine
    {
        string MerchantId { get; set; }

        string RuleId { get; set; }

        string RuleInput { get; set; }

        bool? Enabled { get; set; }
    }
}
