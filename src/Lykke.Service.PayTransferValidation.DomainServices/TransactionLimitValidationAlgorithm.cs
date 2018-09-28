using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [AlgorithmIdentity("65846bd3f-170c-4f22-be8c-79a9a021c102", "Transaction Limit")]
    public sealed class TransactionLimitValidationAlgorithm : ValidationAlgorithm
    {
        public override async Task<AlgorithmValidationResult> ExecuteAsync(Domain.ValidationContext ctx, string input)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateInput(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}
