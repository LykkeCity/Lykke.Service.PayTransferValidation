using System;
using System.Runtime.Serialization;

namespace Lykke.Service.PayTransferValidation.Domain.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException()
        {
        }

        public EntityAlreadyExistsException(string partitionKey, string rowKey) : base("Entity already exists")
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public EntityAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }
}
