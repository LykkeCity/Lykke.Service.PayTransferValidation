using Autofac;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Services;
using Lykke.Service.PayTransferValidation.DomainServices;

namespace Lykke.Service.PayTransferValidation.Modules
{
    [UsedImplicitly]
    public class RulesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ValidationRule).Assembly)
                .Where(x => x.IsSubclassOf(typeof(ValidationRule)))
                .Named(type => type.GetAttributeValue((RuleIdentityAttribute attr) => attr.Id),
                    typeof(IValidationRule));
        }
    }
}
