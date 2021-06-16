using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Facade
    {
        private TV TV { get; set; } = new TV();
        private Movie Movie { get; set; } = new Movie();

        internal void On()
        {
            TV.TurnOn();
            Movie.Pay();
            Movie.View();
        }

        internal void Off()
        {
            Movie.Review();
            TV.TurnOff();
        }
    }

    internal class TV
    {
        internal void TurnOn() => Console.WriteLine("TV 켜기");
        internal void TurnOff() => Console.WriteLine("TV 끄기");
    }

    internal class Movie
    {
        internal void Pay() => Console.WriteLine("영화 결제");
        internal void View() => Console.WriteLine("영화 보기");
        internal void Review() => Console.WriteLine("영화 리뷰");
    }
}
