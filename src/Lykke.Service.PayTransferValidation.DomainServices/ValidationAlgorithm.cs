using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Services;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    public abstract class ValidationAlgorithm : IValidationAlgorithm
    {
        public abstract Task<AlgorithmValidationResult> ExecuteAsync(ValidationContext ctx, string input);

        public abstract IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input);

        protected virtual AlgorithmValidationResult GetSuccessResult()
        {
            return new AlgorithmValidationResult
            {
                DisplayName = GetType().GetAttributeValue((AlgorithmIdentityAttribute attr) => attr.DisplayName),
                IsSuccess = true
            };
        }
    }
}
