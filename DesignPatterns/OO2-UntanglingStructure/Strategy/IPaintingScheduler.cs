using System.Collections.Generic;

namespace OO2_UntanglingStructure.Strategy
{
    public interface IPaintingScheduler<TPainter> where TPainter : IPainter
    {
        IEnumerable<PaintingTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }
}