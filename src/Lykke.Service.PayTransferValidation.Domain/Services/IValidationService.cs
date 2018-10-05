using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.PayTransferValidation.Domain.Services
{
    public interface IValidationService
    {
        Task<ValidationResult> ValidateAsync(ValidationContext ctx);

        IReadOnlyList<RegisteredValidationRule> GetRegisteredRules();
    }
}
