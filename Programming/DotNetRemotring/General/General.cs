using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLib
{
    public class General : MarshalByRefObject
    {
        public string ConvertIntToStr(int i)
        {
            Console.WriteLine($"call ConvertIntoToStr function, parameter : {i}");

            switch(i)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                default:
                    return "unknown number";
            }
        }
    }
}
