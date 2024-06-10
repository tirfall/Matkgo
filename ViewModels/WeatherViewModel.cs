using Matkgo.Models;
using Matkgo.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Matkgo.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private readonly WeatherService _weatherService;
        private WeatherForecast _weatherForecast;

        public WeatherForecast WeatherForecast
        {
            get => _weatherForecast;
            set
            {
                if (_weatherForecast != value)
                {
                    _weatherForecast = value;
                    OnPropertyChanged();
                }
            }
        }

        public WeatherViewModel()
        {
            _weatherService = new WeatherService();
        }

        public async Task LoadWeatherAsync(string location)
        {
            WeatherForecast = await _weatherService.GetWeatherAsync(location);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}