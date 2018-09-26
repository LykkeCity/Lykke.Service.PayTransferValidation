using Lykke.HttpClientGenerator;

namespace Lykke.Service.PayTransferValidation.Client
{
    /// <summary>
    /// PayTransferValidation API aggregating interface.
    /// </summary>
    public class PayTransferValidationClient : IPayTransferValidationClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to PayTransferValidation Api.</summary>
        public IPayTransferValidationApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public PayTransferValidationClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<IPayTransferValidationApi>();
        }
    }
}
