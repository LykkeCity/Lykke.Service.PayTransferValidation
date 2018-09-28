using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.PayTransferValidation.Domain.Services
{
    public interface IValidationAlgorithm
    {
        Task<AlgorithmValidationResult> ExecuteAsync(ValidationContext ctx, string input);

        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input);
    }
}
