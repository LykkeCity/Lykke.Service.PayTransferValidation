using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.PayTransferValidation.Client 
{
    /// <summary>
    /// PayTransferValidation client settings.
    /// </summary>
    public class PayTransferValidationServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
