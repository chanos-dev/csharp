﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class WhiteTiger : Parents
    {
        public override void growl()
        {
            Console.WriteLine("Uh-huh~!! of WhiteTiger");
        }
    }
}
