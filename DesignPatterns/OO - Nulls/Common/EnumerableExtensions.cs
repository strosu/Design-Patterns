using System;
using System.Collections.Generic;
using System.Linq;

namespace OO___Nulls.Common
{
    public static class EnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var obj in enumerable)
            {
                action(obj);
            }
        }
    }
}