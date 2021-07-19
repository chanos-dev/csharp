using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formattable.Model
{
    public class Person : IFormattable
    {
        private const string DEFAULT_FORMAT = "P";

        public string Name { get; set; }

        public int Age { get; set; }

        public string Job { get; set; }

        public override string ToString() => this.ToString(string.Empty, null);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = DEFAULT_FORMAT;

            if (formatProvider is null)
                formatProvider = CultureInfo.CurrentCulture;

            switch (format)
            {
                case DEFAULT_FORMAT:
                    return $"Name : {Name}\nAge : {Age} \nJob : {Job}";
                case "N":
                    return $"Name : {Name}";
                case "A":
                    return $"Age : {Age}";
                case "J":
                    return $"Job : {Job}";
                default:
                    throw new NotImplementedException("format is null");
            }
        }
    }
}
