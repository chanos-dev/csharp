using MediatR;
using MediatRProject.Model;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProject
{
    internal class App : BackgroundService
    {
        private readonly IMediator _mediator;

        public App(IMediator mediator)
        {
            this._mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Run App!!");

            var response = await this._mediator.Send(new Ping());
            Console.WriteLine(response);

            await this._mediator.Send(new OneWay() { Name = "Hello, MediatR!" });

            await this._mediator.Publish(new PingNotification());
        }
    }
}
