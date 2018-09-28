using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AzureStorage;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;
using Lykke.Service.PayTransferValidation.Domain.Repositories;

namespace Lykke.Service.PayTransferValidation.AzureRepositories
{
    public class MerchantConfigurationRepository : IMerchantConfigurationRepository
    {
        private readonly INoSQLTableStorage<MerchantConfigurationLineEntity> _storage;

        public MerchantConfigurationRepository(
            [NotNull] INoSQLTableStorage<MerchantConfigurationLineEntity> storage)
        {
            _storage = storage;
        }

        public async Task<IMerchantConfigurationLine> AddAsync(IMerchantConfigurationLine src)
        {
            MerchantConfigurationLineEntity entity = MerchantConfigurationLineEntity.ByMerchant.Create(src);

            await _storage.InsertThrowConflict(entity);

            return Mapper.Map<MerchantConfigurationLine>(entity);
        }

        public async Task<IMerchantConfigurationLine> GetAsync(string merchantId, string algorithmId)
        {
            MerchantConfigurationLineEntity entity = await _storage.GetDataAsync(
                MerchantConfigurationLineEntity.ByMerchant.GeneratePartitionKey(merchantId),
                MerchantConfigurationLineEntity.ByMerchant.GenerateRowKey(algorithmId));

            return Mapper.Map<MerchantConfigurationLine>(entity);
        }

        public async Task<IReadOnlyList<IMerchantConfigurationLine>> GetByMerchantAsync(string merchantId)
        {
            IEnumerable<MerchantConfigurationLineEntity> entities =
                await _storage.GetDataAsync(
                    MerchantConfigurationLineEntity.ByMerchant.GeneratePartitionKey(merchantId));

            return Mapper.Map<IReadOnlyList<IMerchantConfigurationLine>>(entities);
        }

        public async Task UpdateAsync(IMerchantConfigurationLine src)
        {
            string pKey = MerchantConfigurationLineEntity.ByMerchant.GeneratePartitionKey(src.MerchantId);
            string rKey = MerchantConfigurationLineEntity.ByMerchant.GenerateRowKey(src.AlgorithmId);

            MerchantConfigurationLineEntity updatedEntity = await _storage.MergeAsync(pKey, rKey,
                entity =>
                {
                    if (src.AlgorithmInput != null)
                        entity.AlgorithmInput = src.AlgorithmInput;
                    if (src.Enabled.HasValue)
                        entity.Enabled = src.Enabled.Value;

                    return entity;
                });

            if (updatedEntity == null)
                throw new EntityNotFoundException(pKey, rKey);
        }

        public async Task DeleteAsync(string merchantId, string algorithmId)
        {
            string pKey = MerchantConfigurationLineEntity.ByMerchant.GeneratePartitionKey(merchantId);
            string rKey = MerchantConfigurationLineEntity.ByMerchant.GenerateRowKey(algorithmId);

            MerchantConfigurationLineEntity deletedEntity = await _storage.DeleteAsync(pKey, rKey);

            if (deletedEntity == null)
                throw new EntityNotFoundException(pKey, rKey);
        }
    }
}
