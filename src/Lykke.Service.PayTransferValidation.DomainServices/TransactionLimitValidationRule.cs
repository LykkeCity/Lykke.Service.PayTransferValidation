using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Inputs;
using Newtonsoft.Json;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [RuleIdentity("65846bd3f-170c-4f22-be8c-79a9a021c102", "Transaction Limit")]
    public sealed class TransactionLimitValidationRule : ValidationRule
    {
        private const string ErrorMessage = "The transferring amount breaks the limit per transaction";

        public override Task<RuleValidationResult> ExecuteAsync(Domain.ValidationContext ctx, string input)
        {
            var cfg = JsonConvert.DeserializeObject<TransactionLimitInput>(input);

            var assetCfg = cfg.Limits.SingleOrDefault(x => x.AssetId == ctx.AssetId);

            RuleValidationResult result = GetSuccessResult();

            if (assetCfg != null)
            {
                if (ctx.TransferAmount > assetCfg.Limit)
                {
                    result.Error = ErrorMessage;
                }
            }

            return Task.FromResult(result);
        }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input)
        {
            var typedInput = JsonConvert.DeserializeObject<TransactionLimitInput>(input);

            var inputValidationResult = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            Validator.TryValidateObject(
                typedInput,
                new System.ComponentModel.DataAnnotations.ValidationContext(typedInput, null, null),
                inputValidationResult,
                true);

            return inputValidationResult;
        }
    }
}
