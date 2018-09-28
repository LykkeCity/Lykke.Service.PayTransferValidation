using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.Service.PayTransferValidation.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlidingPeriod
    {
        Day = 0,
        Week,
        Month,
        Year
    }
}
