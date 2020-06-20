using NUnit.Framework;
using WeatherCaller;
using Moq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WeatherCaller.Test
{
    public class ForecasterTests
    {
        [Test]
        public async Task ShouldReturnForecastWeCalled()
        {
            // Assign
            var forecaster = new Forecaster();
            var client = new Mock<IWeatherServiceClient>();
            IWeatherForecast forecastToReturn = new WeatherForecast(10);
            client.Setup(c => c.FetchForecast()).Returns(Task.FromResult(forecastToReturn));
            // Act
            var result = await forecaster.Forecast(client.Object);
            // Assert
            var expected = 10;
            Assert.AreEqual(expected, result.DegreesForToday);
        }
    }
    public class ParserTests
    {

        [Test]
        public async Task ShouldReturnParseFirstTemperatureFromResponseBody()
        {
            // Assign
            var reponseParser = new ResponseParser();
            string responseBodyString = System.IO.File.ReadAllText(@"../../../response.body.json");
            // dynamic responseBody = JObject.Parse(responseBodyString);
            // Act
            var degresCelciumForToday = reponseParser.GetNextTemperature(responseBodyString);
            // Assert
            Assert.AreEqual(297.89M, degresCelciumForToday);
        }
    }
    public class WeatherServiceClientTests
    {
        [Test]
        public async Task ShouldReturnForecastWeCalled()
        {
            // Assign
            var content = "{}";
            var httpClientWrapper = new Mock<IHttpClientWrapper>();
            httpClientWrapper.Setup(w => w.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(content));
            var parser = new Mock<IReponseParser>();
            parser.Setup(p => p.GetNextTemperature(It.IsAny<string>())).Returns(297.89M);
            var weatherServiceClient = new WeatherServiceClient(httpClientWrapper.Object, parser.Object);
            // Act
            var result = await weatherServiceClient.FetchForecast();
            // Assert
            var expected = 25;
            Assert.AreEqual(expected, result.DegreesForToday);
        }
    }

}