using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRoom.DAL
{
    // TODO: Check if deprecated
    public class ConfigurationHelper
    {
        public static string GetCurrentSettings(string key)
        {
            var configFile = "appsettings.json";
#if DEBUG
            configFile = "appsettings.Development.json";
#endif
            var builder = new ConfigurationBuilder()
              .SetBasePath(System.IO.Directory.GetCurrentDirectory())
              .AddJsonFile(configFile, optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetValue<string>(key);
        }
    }
}
