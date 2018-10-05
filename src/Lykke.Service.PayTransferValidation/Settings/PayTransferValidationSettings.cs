using JetBrains.Annotations;

namespace Lykke.Service.PayTransferValidation.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class PayTransferValidationSettings
    {
        public DbSettings Db { get; set; }
    }
}
