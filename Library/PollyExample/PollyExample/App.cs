using Microsoft.Extensions.Hosting;

namespace PollyExample
{ 
    internal class App : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public App(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            HttpClient client = _httpClientFactory.CreateClient("WeatherForecastService");

            HttpResponseMessage badRequestResponse = await client.GetAsync("WeatherForecast/badrequest");

            Console.WriteLine(await badRequestResponse.Content.ReadAsStringAsync());

            HttpResponseMessage successResponse = await client.GetAsync("WeatherForecast");

            Console.WriteLine(await successResponse.Content.ReadAsStringAsync());
        }
    }
}
