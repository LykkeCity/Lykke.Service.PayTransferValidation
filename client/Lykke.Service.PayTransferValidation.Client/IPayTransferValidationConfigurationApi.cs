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
        /// Get validation algorithms configuration for merchant
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        [Get("/api/configuration/{merchantId}")]
        Task<ConfigurationModel> GetAsync(string merchantId);

        /// <summary>
        /// Add new validation algorithm to merchant configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Post("/api/configuration")]
        Task<LineModel> AddAsync([Body] AddLineModel model);

        /// <summary>
        /// Deletes validation algorithm from merchant's configuration
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="algorithmId"></param>
        /// <returns></returns>
        [Delete("/api/configuration/{merchantId}/{algorithmId}")]
        Task DeleteAsync(string merchantId, string algorithmId);

        /// <summary>
        /// Enables validation algorithm in merchant's configuration
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="algorithmId"></param>
        /// <returns></returns>
        [Put("/api/configuration/{merchantId}/{algorithmId}/enable")]
        Task EnableAsync(string merchantId, string algorithmId);

        /// <summary>
        /// Disables validation algorithm in merchant's configuration
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="algorithmId"></param>
        /// <returns></returns>
        [Put("/api/configuration/{merchantId}/{algorithmId}/disable")]
        Task DisableAsync(string merchantId, string algorithmId);

        /// <summary>
        /// Updates validation algorithm input
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Put("/api/configuration")]
        Task UpdateInputAsync([Body] UpdateInputModel model);
    }
}
