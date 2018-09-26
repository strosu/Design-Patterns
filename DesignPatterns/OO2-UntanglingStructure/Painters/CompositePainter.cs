using System;
using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure
{
    public class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        public Func<double, IEnumerable<TPainter>, IPainter> Reduce;
        private readonly IEnumerable<TPainter> _painters;

        public CompositePainter(IEnumerable<TPainter> painters, Func<double, IEnumerable<TPainter>, IPainter> reduce) : this(painters)
        {
            Reduce = reduce;
        }

        public CompositePainter(IEnumerable<TPainter> painters)
        {
            _painters = painters.ToList();
        }

        public bool IsAvailable
        {
            get => _painters.Any(painter => painter.IsAvailable);
            set => throw new Exception();
        }

        public double EstimateCompensation(double sqMeters) =>
            Reduce(sqMeters, _painters).EstimateCompensation(sqMeters);

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Reduce(sqMeters, _painters).EstimateTimeToPaint(sqMeters);
    }
}