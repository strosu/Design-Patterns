using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OO2_UntanglingStructure.Strategy;

namespace OO2_UntanglingStructure
{
    public class CombiningPainter<TPainter> : CompositePainter<TPainter> where TPainter : IPainter
    {
        private readonly IPaintingScheduler<TPainter> _scheduleWork;

        public CombiningPainter(IEnumerable<TPainter> painters,
            IPaintingScheduler<TPainter> scheduleWork) : base(painters)
        {
            _scheduleWork = scheduleWork;
            base.Reduce = Combine;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            var availablePainters = painters.Where(p => p.IsAvailable);
            IEnumerable<PaintingTask<TPainter>> surfacePerPainter = _scheduleWork.Schedule(sqMeters, availablePainters);

            var time = surfacePerPainter.Max(x => x.Painter.EstimateTimeToPaint(x.SqMeters));

            var cost = surfacePerPainter.Max(x => x.Painter.EstimateCompensation(x.SqMeters));

            return new ProportionalPainter
            {
                TimePerSquareMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}