using System.Collections.Generic;

namespace Lykke.Service.PayTransferValidation.Domain
{
    public class ValidationResult
    {
        public IReadOnlyList<RuleValidationResult> Results { get; set; }        
    }
}
