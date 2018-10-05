using Autofac;
using AzureStorage.Tables;
using JetBrains.Annotations;
using Lykke.Common.Log;
using Lykke.Service.PayTransferValidation.AzureRepositories;
using Lykke.Service.PayTransferValidation.Domain.Repositories;
using Lykke.Service.PayTransferValidation.Domain.Services;
using Lykke.Service.PayTransferValidation.DomainServices;
using Lykke.Service.PayTransferValidation.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.PayTransferValidation.Modules
{
    [UsedImplicitly]
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositories(builder);

            RegisterAppServices(builder);
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            const string merchantConfigurationTableName = "MerchantTransferValidationConfiguration";

            builder.Register(c =>
                    new MerchantConfigurationRepository(AzureTableStorage<MerchantConfigurationLineEntity>.Create(
                        _appSettings.ConnectionString(x => x.PayTransferValidationService.Db.DataConnString),
                        merchantConfigurationTableName, c.Resolve<ILogFactory>())))
                .As<IMerchantConfigurationRepository>()
                .SingleInstance();
        }

        private void RegisterAppServices(ContainerBuilder builder)
        {
            builder.RegisterType<MerchantConfigurationService>()
                .As<IMerchantConfigurationService>();

            builder.RegisterType<ValidationService>()
                .As<IValidationService>();
        }
    }
}
