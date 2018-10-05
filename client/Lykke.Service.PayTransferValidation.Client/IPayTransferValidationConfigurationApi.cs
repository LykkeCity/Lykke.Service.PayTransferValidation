using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Client.Models.MerchantConfiguration;
using Refit;

namespace Lykke.Service.PayTransferValidation.Client
{
    /// <summary>
    /// Configuration API
    /// </summary>
    [PublicAPI]
    public interface IPayTransferValidationConfigurationApi
    {
        /// <summary>
        /// Get validation rules configuration for merchant
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        [Get("/api/configuration/{merchantId}")]
        Task<ConfigurationModel> GetAsync(string merchantId);

        /// <summary>
        /// Add new validation rule to merchant configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Post("/api/configuration")]
        Task<LineModel> AddAsync([Body] AddLineModel model);

        /// <summary>
        /// Deletes validation rule from merchant's configuration
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        [Delete("/api/configuration/{merchantId}/{ruleId}")]
        Task DeleteAsync(string merchantId, string ruleId);

        /// <summary>
        /// Enables validation rule in merchant's configuration
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        [Put("/api/configuration/{merchantId}/{ruleId}/enable")]
        Task EnableAsync(string merchantId, string ruleId);

        /// <summary>
        /// Disables validation rule in merchant's configuration
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        [Put("/api/configuration/{merchantId}/{ruleId}/disable")]
        Task DisableAsync(string merchantId, string ruleId);

        /// <summary>
        /// Updates validation rule input
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Put("/api/configuration")]
        Task UpdateInputAsync([Body] UpdateInputModel model);
    }
}
