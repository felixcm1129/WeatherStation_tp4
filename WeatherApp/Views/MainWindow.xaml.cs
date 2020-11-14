using OpenWeatherAPI;
using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            ApiHelper.InitializeClient();
            string config = AppConfiguration.GetValue("OWApiKey");
            ITemperatureService temp_service = new OpenWeatherService(config);

            vm = new TemperatureViewModel(temp_service);

            DataContext = vm;           
        }
    }
}
