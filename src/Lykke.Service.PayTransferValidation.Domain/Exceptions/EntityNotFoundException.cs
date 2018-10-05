using System;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string partitionKey, string rowKey) : base("Entity not found")
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }
}
