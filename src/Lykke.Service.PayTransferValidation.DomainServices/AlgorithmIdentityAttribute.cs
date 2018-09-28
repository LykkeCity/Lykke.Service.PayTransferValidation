using System;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AlgorithmIdentityAttribute : Attribute
    {
        public AlgorithmIdentityAttribute(string id, string displayName)
        {
            Id = id;
            DisplayName = displayName; 
        }

        public string Id { get; }
        public string DisplayName { get; }
    }
}
