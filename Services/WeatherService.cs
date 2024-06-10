using Matkgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//e603de95f144da73b2a32c38e56ed14a

namespace Matkgo.Services
{
    public class WeatherService
    {
        private const string ApiKey = "e603de95f144da73b2a32c38e56ed14a"; // Замените на ваш API-ключ
        private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherForecast> GetWeatherAsync(string location)
        {
            using HttpClient client = new HttpClient();
            //string url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=hourly,daily&appid={ApiKey}";
            string url = $"{BaseUrl}?q={location}&appid={ApiKey}&units=metric";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<OpenWeatherResponse>(json);
                    return new WeatherForecast
                    {
                        Temperature = weatherData.Main.Temp.ToString("0.0"),
                        Condition = weatherData.Weather[0].Description,
                        ForecastDate = DateTime.Now.ToString("g")
                    };
                }
                else
                {
                    throw new Exception("Unable to fetch weather data");
                }
            }
            catch (Exception ex)
            {
                // Логирование исключения
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
                throw; // Проброс исключения для обработки на уровне ViewModel
            }
        }
    }

    public class OpenWeatherResponse
    {
        public Weather[] Weather { get; set; }
        public Main Main { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
    }
}
