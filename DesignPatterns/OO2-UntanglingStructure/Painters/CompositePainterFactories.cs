using System;
using System.Collections.Generic;
using System.Linq;
using OO2_UntanglingStructure.Strategy;

namespace OO2_UntanglingStructure
{
    public static class CompositePainterFactories
    {
        public static IPainter CombineProportional(IEnumerable<ProportionalPainter> painters) =>
            new CombiningPainter<ProportionalPainter>(painters, new ProportionalPaintingScheduler());

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