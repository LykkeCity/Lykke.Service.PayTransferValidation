using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.PayTransferValidation.Domain.Services
{
    public interface IValidationRule
    {
        Task<RuleValidationResult> ExecuteAsync(ValidationContext ctx, string input);

        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input);
    }
}
