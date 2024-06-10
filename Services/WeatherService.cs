using Matkgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Matkgo.Services
{
    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<WeatherForecast> GetWeatherAsync(string location)
        {
            string apiKey = "976f67b88e7d44b0bad40426241006"; // Замените на ваш API ключ
            string url = $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location}&days=1";
            var response = await client.GetStringAsync(url);
            var weatherData = JsonSerializer.Deserialize<WeatherForecast>(response);
            return weatherData;
        }
    }
}
