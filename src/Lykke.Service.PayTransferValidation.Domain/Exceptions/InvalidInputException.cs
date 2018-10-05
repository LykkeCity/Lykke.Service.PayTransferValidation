using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string ruleId, IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> errors) : base(
            "The input for validation rule is not valid")
        {
            RuleId = ruleId;
            Errors = errors;
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string RuleId { get; set; }
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Errors { get; set; }
    }
}
