using System;

namespace Lykke.Service.PayTransferValidation.DomainServices
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RuleIdentityAttribute : Attribute
    {
        public RuleIdentityAttribute(string id, string displayName)
        {
            Id = id;
            DisplayName = displayName; 
        }

        public string Id { get; }
        public string DisplayName { get; }
    }
}
