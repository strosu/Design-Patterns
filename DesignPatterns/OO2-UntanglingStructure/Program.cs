using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO2_UntanglingStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var painters = Initialize();
            var cheapest = GetCheapersPainter(1.0, painters);
            var cheapest2 = FindCheapest(1.0, painters);

            Console.WriteLine(cheapest.EstimateCompensation(1.0));
            Console.WriteLine(cheapest2.EstimateCompensation(1.0));

            Console.ReadLine();
        }

        private static IPainter FindCheapest(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(p => p.IsAvailable)
                .WithMinimum(painter => painter.EstimateCompensation(sqMeters));
        }

        private static IPainter GetCheapersPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            var min = double.MaxValue;
            IPainter minPainter = null;

            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    if (painter.EstimateCompensation(sqMeters) < min)
                    {
                        min = painter.EstimateCompensation(sqMeters);
                        minPainter = painter;
                    }
                }
            }

            return minPainter;
        }

        static IList<IPainter> Initialize()
        {
            var painters = new List<IPainter>();

            painters.Add(new Painter()
            {
                IsAvailable = false,
                Rate = 1
            });

            painters.Add(new Painter()
            {
                IsAvailable = true,
                Rate = 2
            });

            painters.Add(new Painter()
            {
                IsAvailable = true,
                Rate = 3
            });

            painters.Add(new Painter()
            {
                IsAvailable = true,
                Rate = 4
            });

            painters.Add(new Painter()
            {
                IsAvailable = false,
                Rate = 5
            });

            painters.Add(new Painter()
            {
                IsAvailable = true,
                Rate = 6
            });

            return painters;
        }

    }
}
