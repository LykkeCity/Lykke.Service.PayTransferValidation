using System;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class ValidationRuleNotFoundException : Exception
    {
        public ValidationRuleNotFoundException()
        {
        }

        public ValidationRuleNotFoundException(string ruleId) : base("Validation rule not found")
        {
            RuleId = ruleId;
        }

        public ValidationRuleNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationRuleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string RuleId { get; set; }
    }
}
