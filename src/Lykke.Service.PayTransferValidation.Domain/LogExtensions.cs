using Common;

namespace Lykke.Service.PayTransferValidation.Domain
{
    public static class LogExtensions
    {
        public static string ToDetails(this object src)
        {
            return $"details: {src?.ToJson()}";
        }
    }
}
