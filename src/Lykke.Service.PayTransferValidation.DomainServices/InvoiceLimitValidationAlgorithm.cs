using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [AlgorithmIdentity("8b70b7e4-443c-45e1-be7b-199fc5178441", "Invoice Limit")]
    public class InvoiceLimitValidationAlgorithm : ValidationAlgorithm
    {
        private const string ErrorMessage = "The transferring amount is more than expected";
        
        public override Task<AlgorithmValidationResult> ExecuteAsync(ValidationContext ctx, string input)
        {
            AlgorithmValidationResult result = GetSuccessResult();

            if (ctx.TransferAmount > ctx.ExpectedAmount)
            {
                result.IsSuccess = false;
                result.Error = ErrorMessage;
            }

            return Task.FromResult(result);
        }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}
