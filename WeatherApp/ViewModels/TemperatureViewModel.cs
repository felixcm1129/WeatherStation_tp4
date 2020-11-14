using System;
using System.Threading.Tasks;
using WeatherApp.Commands;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        private TemperatureModel currentTemp;

        public ITemperatureService TemperatureService { get; private set; }

        public DelegateCommand<string> GetTempCommand { get; set; }

        public TemperatureModel CurrentTemp 
        { 
            get => currentTemp;
            set
            {
                currentTemp = value;
                OnPropertyChanged();
                OnPropertyChanged("RawText");
            }
        }

        public string RawText {
            get {
                if (CurrentTemp != null)
                    return $"Time : {CurrentTemp.DateTime.ToLocalTime()} {Environment.NewLine}Temperature : {CurrentTemp.Temperature}";
                else
                    return string.Empty;
            }
        }

        public TemperatureViewModel(ITemperatureService temp)
        {
            GetTempCommand = new DelegateCommand<string>(GetTemp, CanGetTemp);
            SetTemperatureService(temp);
        }

        public bool CanGetTemp(string obj)
        {
            return TemperatureService != null;
        }

        public void GetTemp(string obj)
        {
            if (TemperatureService == null) throw new NullReferenceException();
            else _ =  GetTempAsync();
            
        }

        private async Task GetTempAsync()
        {
            CurrentTemp = await TemperatureService.GetTempAsync();
        }

        public void SetTemperatureService(ITemperatureService srv)
        {
            TemperatureService = srv;
        }
    }
}
