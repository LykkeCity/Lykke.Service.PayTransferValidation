﻿using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.PayTransferValidation.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }

        [AzureTableCheck]
        public string DataConnString { get; set; }
    }
}
