using System.Threading.Tasks;
using JetBrains.Annotations;
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
        /// Validates transfer against merchant configuration algorithms
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Post("/api/validation")]
        Task<ValidationResultModel> ExecuteAsync([Body] ValidationContextModel model);
    }
}
