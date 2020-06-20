using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherCaller
{

    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            var key = ""; // TODO: move this to secrets
            var httpClientWrapper = new HttpClientWrapper(client);
            var parser = new ResponseParser();
            var weatherServiceClient = new WeatherServiceClient(httpClientWrapper, parser, key);
            var forecaster = new Forecaster();
            var weatherForecast = await forecaster.Forecast(weatherServiceClient);
            Console.WriteLine($"Forecast is: {weatherForecast.DegreesForToday}");
        }
    }
    public interface IWeatherForecast
    {
        int DegreesForToday { get; }

    }
    public class WeatherForecast : IWeatherForecast
    {
        public int DegreesForToday { get; }
        public WeatherForecast(int degreesCelcium)
        {
            this.DegreesForToday = degreesCelcium;
        }
    }
    public interface IForecaster
    {
        Task<IWeatherForecast> Forecast(IWeatherServiceClient client);
    }
    public class Forecaster : IForecaster
    {
        public async Task<IWeatherForecast> Forecast(IWeatherServiceClient client)
        {
            return await client.FetchForecast();
        }
    }
    public interface IWeatherServiceClient
    {
        Task<IWeatherForecast> FetchForecast();
    }


    public interface IHttpClientWrapper
    {
        Task<string> GetAsync(string url);
    }

    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient _client;
        public HttpClientWrapper(HttpClient client)
        {
            this._client = client;
        }
        public async Task<string> GetAsync(string url)
        {
            HttpResponseMessage response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBodyString = await response.Content.ReadAsStringAsync();
            return responseBodyString;
        }
    }

    public class WeatherServiceClient : IWeatherServiceClient
    {
        private IHttpClientWrapper _client;
        private IReponseParser _parser;
        private string _service_key;
        public WeatherServiceClient(IHttpClientWrapper client, IReponseParser parser, string key)
        {
            this._client = client;
            this._parser = parser;
            this._service_key = key;
        }
        public async Task<IWeatherForecast> FetchForecast()
        {
            const string TASHKENT_ID = "1512569";
            string url = $"http://api.openweathermap.org/data/2.5/forecast?id={TASHKENT_ID}&APPID={this._service_key}";
            var responseBody = await this._client.GetAsync(url);
            var degreesKelvin = this._parser.GetNextTemperature(responseBody);
            var degreesCelcium = Decimal.Subtract(degreesKelvin, 273.15M);
            return new WeatherForecast(Convert.ToInt32(degreesCelcium));
        }
    }
    public interface IReponseParser
    {
        decimal GetNextTemperature(string responseBody);
    }
    public class ResponseParser : IReponseParser
    {
        public decimal GetNextTemperature(string responseBody)
        {
            // TODO: can be improved with types
            dynamic root = JObject.Parse(responseBody);
            dynamic list = root.list;
            dynamic firstForecastTemperature = list[0].main.temp;
            return firstForecastTemperature;
        }
    }
}
