using System;

namespace OO2_UntanglingStructure
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSquareMeter { get; set; }
        public double DollarsPerHour { get; set; }

        public bool IsAvailable { get; set; }

        public double EstimateCompensation(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours((TimePerSquareMeter.TotalHours * sqMeters));
    }
}