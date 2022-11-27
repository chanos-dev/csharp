using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProject.Model
{
    internal class OneWayHandler : AsyncRequestHandler<OneWay>
    {
        protected override Task Handle(OneWay request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"one way handler : {request.Name}");
            return Task.CompletedTask;
        }
    }
}
