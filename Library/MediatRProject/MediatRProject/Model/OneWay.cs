using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProject.Model
{
    internal class OneWay : IRequest
    {
        internal string Name { get; set; }
    }
}
