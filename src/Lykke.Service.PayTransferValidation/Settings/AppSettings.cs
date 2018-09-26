using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.PayTransferValidation.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public PayTransferValidationSettings PayTransferValidationService { get; set; }
    }
}
