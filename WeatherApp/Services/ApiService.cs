using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
	internal static class ApiService
	{
		public static async Task<Root> GetWeather(double latitude, double longtitude)
		{
			var httpsClient = new HttpClient();
			var response = await httpsClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=b1d2b42b6f989c0386995bd3c43afc69",latitude,longtitude));
			return JsonConvert.DeserializeObject<Root>(response);
		}
		public static async Task<Root> GetWeatherByCity(string city)
		{
			var httpsClient = new HttpClient();
			var response = await httpsClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid=b1d2b42b6f989c0386995bd3c43afc69", city));
			return JsonConvert.DeserializeObject<Root>(response);
		}
	}
}
