namespace OO2_UntanglingStructure
{
    public interface IPainter
    {
        bool IsAvailable { get; set; }

        double EstimateCompensation(double sqMeters);
    }

    public class Painter : IPainter
    {
        public bool IsAvailable { get; set; }

        public int Rate { get; set; }

        public double EstimateCompensation(double sqMeters)
        {
            return Rate * sqMeters;
        }
    }
}