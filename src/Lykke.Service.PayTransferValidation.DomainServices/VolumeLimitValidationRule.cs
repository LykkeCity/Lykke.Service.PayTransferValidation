using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Inputs;
using Newtonsoft.Json;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [RuleIdentity("6099d02f-bc4b-41c6-afa0-ff654f7345c9", "Volume Limit")]
    public sealed class VolumeLimitValidationRule : ValidationRule
    {
        public override async Task<RuleValidationResult> ExecuteAsync(Domain.ValidationContext ctx, string input)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input)
        {
            var typedInput = JsonConvert.DeserializeObject<VolumeLimitInput>(input);

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
