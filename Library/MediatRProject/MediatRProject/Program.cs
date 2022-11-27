using MediatR;
using MediatRProject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder() 
    .ConfigureServices(services =>
    {
        services.AddHostedService<App>();
        services.AddMediatR(typeof(Program));
    })
    .RunConsoleAsync();