using System;
using System.Collections.Generic;
using System.Linq;

namespace OO2_UntanglingStructure
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criteria) 
            where TKey : IComparable 
            where T : class
        {
            return sequence
                .Select(obj => new Tuple<T, TKey>(obj, criteria(obj)))
                .Aggregate((Tuple<T, TKey>)null, (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
                .Item1;
        }
    }
}