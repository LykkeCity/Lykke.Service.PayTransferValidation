using Autofac;
using JetBrains.Annotations;
using Lykke.Service.PayTransferValidation.Domain;
using Lykke.Service.PayTransferValidation.Domain.Services;
using Lykke.Service.PayTransferValidation.DomainServices;

namespace Lykke.Service.PayTransferValidation.Modules
{
    [UsedImplicitly]
    public class AlgorithmsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ValidationAlgorithm).Assembly)
                .Where(x => x.IsSubclassOf(typeof(ValidationAlgorithm)))
                .Named(type => type.GetAttributeValue((AlgorithmIdentityAttribute attr) => attr.Id),
                    typeof(IValidationAlgorithm));
        }
    }
}
