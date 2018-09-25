using System;

namespace OO2_UntanglingStructure
{
    public class Painter : IPainter
    {
        public bool IsAvailable { get; set; }

        public int Rate { get; set; }

        public double EstimateCompensation(double sqMeters)
        {
            return Rate * sqMeters;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return TimeSpan.FromHours(5);
        }
    }
}