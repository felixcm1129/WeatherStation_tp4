using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;

        public static string GetValue(string key)
        {
            if (configuration == null)
            {
                initConfig();
            }
            return configuration[key];
        }

        private static void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", true, true);

            builder.AddUserSecrets<MainWindow>();

            configuration = builder.Build();

        }
    }
}
