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
                .Aggregate(
                    default(T), 
                    (best, cur) => best == null || criteria(best).CompareTo(criteria(cur)) > 0 ? cur : best);
        }
    }
}