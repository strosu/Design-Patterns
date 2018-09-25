using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure
{
    public class Painters
    {
        private readonly IEnumerable<IPainter> _internalPainters;

        public Painters(IEnumerable<IPainter> internalPainters)
        {
            _internalPainters = internalPainters;
        }

        public Painters GetAvailable()
        {
            return new Painters(_internalPainters.Where(painter => painter.IsAvailable));
        }

        public IPainter GetCheapestOne(double sqMeters) => 
            _internalPainters.WithMinimum(painter => painter.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            _internalPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));

    }
}