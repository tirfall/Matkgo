using Matkgo.Models;
using Matkgo.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

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
                _weatherForecast = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadWeatherCommand { get; }

        public WeatherViewModel()
        {
            _weatherService = new WeatherService();
            LoadWeatherCommand = new Command<string>(async (location) => await LoadWeatherAsync(location));
        }

        public async Task LoadWeatherAsync(string location)
        {
            try
            {
                WeatherForecast = await _weatherService.GetWeatherAsync(location);
            }
            catch (Exception ex)
            {
                // Уведомление пользователя о проблеме
                await Application.Current.MainPage.DisplayAlert("Error", $"Unable to fetch weather data: {ex.Message}", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}