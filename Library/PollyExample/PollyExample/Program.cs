using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using PollyExample;

await Host.CreateDefaultBuilder()          
          .ConfigureServices(services =>
          {
              services.AddHttpClient("WeatherForecastService", client =>
                      {
                          client.BaseAddress = new Uri("http://localhost:5208");
                      })
                      .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
                                        .OrResult(msg => !msg.IsSuccessStatusCode)
                                        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

              services.AddHostedService<App>();
          })  
          .UseConsoleLifetime()
          .RunConsoleAsync();