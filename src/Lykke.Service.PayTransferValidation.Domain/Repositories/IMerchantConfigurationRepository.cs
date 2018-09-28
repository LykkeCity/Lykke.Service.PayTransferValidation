using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.PayTransferValidation.Domain.Repositories
{
    public interface IMerchantConfigurationRepository
    {
        Task<IMerchantConfigurationLine> AddAsync(IMerchantConfigurationLine src);

        Task<IMerchantConfigurationLine> GetAsync(string merchantId, string algorithmId);

        Task<IReadOnlyList<IMerchantConfigurationLine>> GetByMerchantAsync(string merchantId);

        Task UpdateAsync(IMerchantConfigurationLine src);

        Task DeleteAsync(string merchantId, string algorithmId);
    }
}
