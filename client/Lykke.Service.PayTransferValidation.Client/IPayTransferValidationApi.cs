using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Client.Models.Rule;
using Lykke.Service.PayTransferValidation.Client.Models.Validation;
using Refit;

namespace Lykke.Service.PayTransferValidation.Client
{
    // This is an example of service controller interfaces.
    // Actual interface methods must be placed here (not in IPayTransferValidationClient interface).

    /// <summary>
    /// PayTransferValidation client API
    /// </summary>
    [PublicAPI]
    public interface IPayTransferValidationApi
    {
        /// <summary>
        /// Validates transfer against merchant configuration rules
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Get("/api/validation")]
        Task<ValidationResultModel> ValidateAsync([Query] ValidationContextModel model);

        /// <summary>
        /// Get list of registered validation rules in the system
        /// </summary>
        /// <returns></returns>
        [Get("/api/validation/rules")]
        Task<IEnumerable<RegisteredRuleModel>> GetRegisteredRules();
    }
}
