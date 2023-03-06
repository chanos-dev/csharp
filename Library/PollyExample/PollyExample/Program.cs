using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
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
                                        .Or<TimeoutRejectedException>()
                                        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
                      .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(3)); 

              services.AddHostedService<App>();
          })  
          .UseConsoleLifetime()
          .RunConsoleAsync();