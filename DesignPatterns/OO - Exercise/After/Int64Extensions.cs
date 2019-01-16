using System.Collections.Generic;
using System.Linq;

namespace OO___Exercise.After
{
    public static class Int64Extensions
    {
        internal static IEnumerable<int> GetDigitsFromLowest(this long number)
        {
            while (number > 0)
            {
                yield return (int)(number % 10);
                number /= 10;
            }
        }

        internal static IEnumerable<int> GetDigitsFromHighest(this long number) =>
            GetDigitsFromLowest(number).Reverse();
    }
}