using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Player { Name = "p1" };
            var p2 = new Player { Name = "p2" };
            var p3 = new Player { Name = "p3" };
            var p4 = new Player { Name = "p4" };
            var p5 = new Player { Name = "p5" };

            var g1 = new Group {Players = {p2, p3}};
            var g2 = new Group {Players = {g1, p4, p5}};
            var g3 = new Group {Players = {p1, g2}};

            g3.Gold = 1000;
            g3.Stats();

            Console.ReadLine();

        }
    }
}
