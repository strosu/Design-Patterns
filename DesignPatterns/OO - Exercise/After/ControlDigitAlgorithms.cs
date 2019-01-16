using System.Collections.Generic;

namespace OO___Exercise.After
{
    public static class ControlDigitAlgorithms
    {
        public static ControlDigitAlgorithm ForLegal = new ControlDigitAlgorithm(Int64Extensions.GetDigitsFromLowest, Factors, 7);
        public static ControlDigitAlgorithm ForFinance = new ControlDigitAlgorithm(Int64Extensions.GetDigitsFromHighest, Factors, 9);

        private static IEnumerable<int> Factors
        {
            get
            {
                var factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }
    }
}