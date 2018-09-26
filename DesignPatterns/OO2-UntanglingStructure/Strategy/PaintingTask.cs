using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO2_UntanglingStructure.Strategy
{
    public class PaintingTask<TPainter> where TPainter : IPainter
    {
        public IPainter Painter { get; }
        public double SqMeters { get; }

        public PaintingTask(TPainter painter, double sqMeters)
        {
            Painter = painter;
            SqMeters = sqMeters;
        }
    }
}
