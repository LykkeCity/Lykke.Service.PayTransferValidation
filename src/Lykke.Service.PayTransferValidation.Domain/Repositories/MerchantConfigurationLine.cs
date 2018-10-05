namespace Lykke.Service.PayTransferValidation.Domain.Repositories
{
    public class MerchantConfigurationLine : IMerchantConfigurationLine
    {
        public string MerchantId { get; set; }
        public string RuleId { get; set; }
        public string RuleInput { get; set; }
        public bool? Enabled { get; set; }
    }
}
