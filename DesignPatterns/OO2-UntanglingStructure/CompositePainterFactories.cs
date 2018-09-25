using System;
using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure
{
    public class CompositePainterFactories
    {
        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> painters) =>
            new CompositePainter<ProportionalPainter>(painters, (sqMeters, sequence) =>
            {
                var time = TimeSpan.FromHours(
                    1 / sequence
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum()
                );

                double cost =
                    sequence
                        .Where(p => p.IsAvailable)
                        .Select(p => p.EstimateCompensation(sqMeters) / p.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                        .Sum();

                return new ProportionalPainter
                {
                    TimePerSquareMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                    DollarsPerHour = cost / time.TotalHours
                };
            });

        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) =>
                    new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));

        public static IPainter GetFastestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) =>
                    new Painters(sequence).GetAvailable().GetFastestOne(sqMeters));
    }
}