using System;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class ValidationAlgorithmNotFoundException : Exception
    {
        public ValidationAlgorithmNotFoundException()
        {
        }

        public ValidationAlgorithmNotFoundException(string algorithmId) : base("Validation algorithm not found")
        {
            AlgorithmId = algorithmId;
        }

        public ValidationAlgorithmNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationAlgorithmNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string AlgorithmId { get; set; }
    }
}
