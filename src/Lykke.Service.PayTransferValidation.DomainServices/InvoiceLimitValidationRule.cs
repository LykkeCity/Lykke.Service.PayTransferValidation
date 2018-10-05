using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [RuleIdentity("8b70b7e4-443c-45e1-be7b-199fc5178441", "Invoice Limit")]
    public class InvoiceLimitValidationRule : ValidationRule
    {
        private const string ErrorMessage = "The transferring amount is more than expected";
        
        public override Task<RuleValidationResult> ExecuteAsync(ValidationContext ctx, string input)
        {
            RuleValidationResult result = GetSuccessResult();

            if (ctx.TransferAmount > ctx.ExpectedAmount)
            {
                result.Error = ErrorMessage;
            }

            return Task.FromResult(result);
        }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input)
        {
            string ruleId = GetType().GetAttributeValue((RuleIdentityAttribute attr) => attr.Id);

            throw new InputNotRequiredException(ruleId);
        }
    }
}
