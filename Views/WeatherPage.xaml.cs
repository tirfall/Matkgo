using Matkgo.ViewModels;

namespace Matkgo.Views
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            var viewModel = (WeatherViewModel)BindingContext;
            var locationEntry = (Entry)FindByName("LocationEntry"); // Получаем доступ к элементу Entry по его имени
            await viewModel.LoadWeatherAsync(locationEntry.Text); // Используем текст из Entry для загрузки погоды
        }
    }
}