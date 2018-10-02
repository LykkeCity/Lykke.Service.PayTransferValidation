using System;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class InputNotRequiredException : Exception
    {
        public InputNotRequiredException()
        {
        }

        public InputNotRequiredException(string ruleId) : base("Input is not required for the rule")
        {
            RuleId = ruleId;
        }

        public InputNotRequiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InputNotRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string RuleId { get; set; }
    }
}
