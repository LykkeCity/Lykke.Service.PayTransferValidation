using Autofac;
using AutoMapper;
using JetBrains.Annotations;

namespace Lykke.Service.PayTransferValidation.Modules
{
    [UsedImplicitly]
    internal class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AzureRepositories.AutoMapperProfile));
                cfg.AddProfiles(typeof(AutoMapperProfile));
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
