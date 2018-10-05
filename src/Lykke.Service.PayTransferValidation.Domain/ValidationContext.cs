namespace Lykke.Service.PayTransferValidation.Domain
{
    public class ValidationContext
    {
        public string MerchantId { get; set; }

        public decimal TransferAmount { get; set; }

        public decimal ExpectedAmount { get; set; }

        public string AssetId { get; set; }
    }
}
