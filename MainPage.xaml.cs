using Matkgo.Views;

namespace Matkgo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnWeatherClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherPage());
        }
        private async void OnGuideClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuidesPage());
        }
    }

}
