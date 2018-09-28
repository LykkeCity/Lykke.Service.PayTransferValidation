using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Newtonsoft.Json.Linq;

namespace Lykke.Service.PayTransferValidation.Domain.Services
{
    public interface IMerchantConfigurationService
    {
        Task<IMerchantConfigurationLine> AddAsync(IMerchantConfigurationLine src);

        Task<IMerchantConfigurationLine> GetAsync(string merchantId, string algorithmId);

        Task<IReadOnlyList<IMerchantConfigurationLine>> GetByMerchantAsync(string merchantId);

        Task EnableAsync(string merchantId, string algorithmId);

        Task DisableAsync(string merchantId, string algorithmId);

        Task UpdateAlgorithmInputAsync(string merchantId, string algorithmId, string algorithmInput);

        Task DeleteAsync(string merchantId, string algorithmId);
    }
}
