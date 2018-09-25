using System;

namespace OO2_UntanglingStructure
{
    public interface IPainter
    {
        bool IsAvailable { get; set; }

        double EstimateCompensation(double sqMeters);

        TimeSpan EstimateTimeToPaint(double sqMeters);
    }
}