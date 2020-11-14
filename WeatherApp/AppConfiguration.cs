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
                key = configuration.GetSection("Configuration")["OWApikey"];
                return key;

            }
            key = configuration.GetSection("Configuration")["OWApikey"];
            return key;
        }

        private static void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            builder.AddUserSecrets<MainWindow>();

            //Environement
            var devEnvVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvVariable) ||
                                    devEnvVariable.ToLower() == "development";

            if (isDevelopment)
            {
                builder.AddUserSecrets<MainWindow>();
            }


            configuration = builder.Build();

        }
    }
}
