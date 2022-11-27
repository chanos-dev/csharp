using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProject.Model
{
    internal class Pong2 : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Something(notification);
            return Task.CompletedTask;
        }

        private void Something(PingNotification notification)
        {
            Console.WriteLine("Open Pong2");
            Console.WriteLine($"Send {notification.Contents!}");
            Console.WriteLine("Close Pong2");
        }
    }
}
