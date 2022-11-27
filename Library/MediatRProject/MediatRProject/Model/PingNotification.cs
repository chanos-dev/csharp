using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProject.Model
{
    internal class PingNotification : INotification
    {
        internal string? Contents { get; set; }
    } 
}
