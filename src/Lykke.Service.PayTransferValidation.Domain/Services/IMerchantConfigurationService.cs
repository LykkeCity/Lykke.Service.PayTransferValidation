using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.PayTransferValidation.Domain.Repositories;

namespace Lykke.Service.PayTransferValidation.Domain.Services
{
    public interface IMerchantConfigurationService
    {
        Task<IMerchantConfigurationLine> AddAsync(IMerchantConfigurationLine src);

        Task<IMerchantConfigurationLine> GetAsync(string merchantId, string ruleId);

        Task<IReadOnlyList<IMerchantConfigurationLine>> GetByMerchantAsync(string merchantId);

        Task EnableAsync(string merchantId, string ruleId);

        Task DisableAsync(string merchantId, string ruleId);

        Task UpdateRuleInputAsync(string merchantId, string ruleId, string ruleInput);

        Task DeleteAsync(string merchantId, string ruleId);
    }
}
