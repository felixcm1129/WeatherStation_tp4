using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using System.Threading.Tasks;
using OpenWeatherAPI;
using WeatherApp.Converter;

namespace WeatherApp
{
    public class OpenWeatherService : ITemperatureService
    {
        public OpenWeatherProcessor owp;

        public TemperatureModel LastTemp;

        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }

        public async Task<TemperatureModel> GetTempAsync()
        {
            try
            {
                var currentweather = await owp.GetCurrentWeatherAsync();
                TemperatureModel temp = new TemperatureModel();

                DateTime birth = new DateTime(1997, 10, 23, 9, 45, 29, DateTimeKind.Utc);
                temp.DateTime = birth.AddSeconds(currentweather.DateTime).ToLocalTime();

                temp.Temperature = currentweather.Main.Temperature;
                TemperatureConverter.FahrenheitInCelsius(temp.Temperature);
                temp.Temperature = Math.Round(temp.Temperature, 0);

                LastTemp = temp;

                return temp;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }

            return null;
        }
    }
}
