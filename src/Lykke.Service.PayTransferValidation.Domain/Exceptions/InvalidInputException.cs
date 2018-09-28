using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string algorithmId, IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> errors) : base(
            "The input for validation algorithm is not valid")
        {
            AlgorithmId = algorithmId;
            Errors = errors;
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string AlgorithmId { get; set; }
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Errors { get; set; }
    }
}
