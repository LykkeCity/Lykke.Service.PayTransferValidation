using Lykke.Job.PayTransferValidation.Settings.JobSettings;
using Lykke.Job.PayTransferValidation.Settings.SlackNotifications;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Job.PayTransferValidation.Settings
{
    public class AppSettings
    {
        public PayTransferValidationJobSettings PayTransferValidationJob { get; set; }

        public SlackNotificationsSettings SlackNotifications { get; set; }

        [Optional]
        public MonitoringServiceClientSettings MonitoringServiceClient { get; set; }
    }
}
