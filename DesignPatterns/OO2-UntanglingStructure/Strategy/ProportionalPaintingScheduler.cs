using System;
using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure.Strategy
{
    class ProportionalPaintingScheduler : IPaintingScheduler<ProportionalPainter>
    {
        public IEnumerable<PaintingTask<ProportionalPainter>> Schedule(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            var velocities =
                painters
                    .Select(painter =>
                        Tuple.Create(painter, sqMeters / painter.EstimateTimeToPaint(sqMeters).TotalHours))
                    .ToList();

            var totalVelocity = velocities.Sum(x => x.Item2);

            return velocities
                .Select(x =>
                    new PaintingTask<ProportionalPainter>(x.Item1, sqMeters * x.Item2 / totalVelocity))
                .ToList();
        }
    }
}