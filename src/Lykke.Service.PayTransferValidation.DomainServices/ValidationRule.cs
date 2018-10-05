using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Services;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    public abstract class ValidationRule : IValidationRule
    {
        public abstract Task<RuleValidationResult> ExecuteAsync(ValidationContext ctx, string input);

        public abstract IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input);

        protected virtual RuleValidationResult GetSuccessResult()
        {
            return new RuleValidationResult
            {
                DisplayName = GetType().GetAttributeValue((RuleIdentityAttribute attr) => attr.DisplayName),
                IsSuccess = true
            };
        }
    }
}
