using System;
using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var painters = Initialize();
            var cheapest2 = new Painters(painters).GetCheapestOne(1.0);
            Console.WriteLine(cheapest2.EstimateCompensation(1.0));

            var cheapestPainter = CompositePainterFactories.CreateCheapestSelector(painters);
            Console.WriteLine(cheapestPainter.EstimateCompensation(1.0));

            var group = CompositePainterFactories.CombineProportional(painters);
            Console.WriteLine(group.EstimateCompensation(1.0));

            Console.ReadLine();
        }
        

        static IEnumerable<ProportionalPainter> Initialize()
        {
            var painters = new List<ProportionalPainter>();

            painters.Add(new ProportionalPainter
            {
                IsAvailable = false,
                TimePerSquareMeter = TimeSpan.FromHours(1),
                DollarsPerHour = 10
            });

            painters.Add(new ProportionalPainter()
            {
                IsAvailable = true,
                TimePerSquareMeter = TimeSpan.FromHours(2),
                DollarsPerHour = 20
            });

            return painters.ToList();
        }

    }
}
