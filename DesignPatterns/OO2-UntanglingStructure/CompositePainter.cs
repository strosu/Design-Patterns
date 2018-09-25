using System;
using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure
{
    public class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        private readonly Func<double, IEnumerable<TPainter>, IPainter> _reduce;
        private readonly IEnumerable<TPainter> _painters;

        public CompositePainter(IEnumerable<TPainter> painters, Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            _reduce = reduce;
            _painters = painters.ToList();
        }

        public bool IsAvailable
        {
            get => _painters.Any(painter => painter.IsAvailable);
            set => throw new Exception();
        }

        public double EstimateCompensation(double sqMeters) =>
            _reduce(sqMeters, _painters).EstimateCompensation(sqMeters);

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            _reduce(sqMeters, _painters).EstimateTimeToPaint(sqMeters);
    }
}