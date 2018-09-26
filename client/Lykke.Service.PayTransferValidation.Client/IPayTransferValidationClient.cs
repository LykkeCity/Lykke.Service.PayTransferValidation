using JetBrains.Annotations;

namespace Lykke.Service.PayTransferValidation.Client
{
    /// <summary>
    /// PayTransferValidation client interface.
    /// </summary>
    [PublicAPI]
    public interface IPayTransferValidationClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - IPayTransferValidationApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application Api interface</summary>
        IPayTransferValidationApi Api { get; }
    }
}
