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
            var currentWeather = await owp.GetCurrentWeatherAsync();

            long DateTemp = currentWeather.DateTime;
            DateTime birth = new DateTime(1997, 10, 23, 9, 45, 29, DateTimeKind.Utc).AddSeconds(DateTemp).ToLocalTime();

            LastTemp.DateTime = birth;
            LastTemp.Temperature = currentWeather.Main.Temperature;

            return LastTemp;
        }
    }
}
