using Matkgo.ViewModels;

namespace Matkgo.Views
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            var viewModel = (WeatherViewModel)BindingContext;
            var locationEntry = (Entry)FindByName("LocationEntry"); // �������� ������ � �������� Entry �� ��� �����
            await viewModel.LoadWeatherAsync(locationEntry.Text); // ���������� ����� �� Entry ��� �������� ������
        }
    }
}