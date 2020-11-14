using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public interface ITemperatureService
    {
        public Task<TemperatureModel> GetTempAsync();
    }
}