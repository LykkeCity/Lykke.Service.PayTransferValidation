using AutoMapper;
using Lykke.AzureStorage.Tables;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;
using Lykke.Service.PayTransferValidation.Domain.Repositories;

namespace Lykke.Service.PayTransferValidation.AzureRepositories
{
    [ValueTypeMergingStrategy(ValueTypeMergingStrategy.UpdateIfDirty)]
    public class MerchantConfigurationLineEntity : AzureTableEntity
    {
        private bool _enabled;

        public string MerchantId { get; set; }

        public string RuleId { get; set; }

        public string RuleInput { get; set; }

        public bool Enabled
        {
            get => _enabled;

            set
            {
                _enabled = value;
                MarkValueTypePropertyAsDirty(nameof(Enabled));
            }
        }

        public static class ByMerchant
        {
            public static string GeneratePartitionKey(string merchantId)
            {
                return merchantId;
            }

            public static string GenerateRowKey(string ruleId)
            {
                return ruleId;
            }

            public static MerchantConfigurationLineEntity Create(IMerchantConfigurationLine src)
            {
                var entity = new MerchantConfigurationLineEntity
                {
                    PartitionKey = GeneratePartitionKey(src.MerchantId),
                    RowKey = GenerateRowKey(src.RuleId)
                };

                return Mapper.Map(src, entity);
            }
        }
    }
}
