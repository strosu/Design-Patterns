using System;

namespace OO___Nulls
{
    public class Part
    {
        public DateTime InstallDate { get; }
        public DateTime BreakDate { get; private set; }

        public Part(DateTime installDate)
        {
            InstallDate = installDate;
        }

        public void MarkDefective(DateTime breakDate)
        {
            BreakDate = breakDate;
        }
    }
}
