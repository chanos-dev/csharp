using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProject.Model
{
    internal class Pong1 : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Something(notification);
            return Task.CompletedTask;
        }

        private void Something(PingNotification notification)
        {
            Console.WriteLine("Open Pong1");
            Console.WriteLine($"Write {notification.Contents!}");
            Console.WriteLine("Close Pong1");
        }
    }
}
