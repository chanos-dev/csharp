using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorManager = new ColorManager();

            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            Color color1 = colorManager["red"].Clone() as Color;
            Color color2 = colorManager["peace"].Clone() as Color;
            Color color3 = colorManager["flame"].Clone() as Color;

            Console.WriteLine(object.ReferenceEquals(colorManager["red"], color1));
        }
    }

    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    public class Color : ColorPrototype
    {
        private int Red { get; set; }

        private int Green { get; set; }

        private int Blue { get; set; }

        public Color(int r, int g, int b)
        {
            this.Red = r;
            this.Green = g;
            this.Blue = b;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine($"Cloning color RGB : {Red}, {Green}, {Blue}");

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> Colors { get; set; } = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get => Colors[key];
            set => Colors[key] = value;
        }
    }
}
