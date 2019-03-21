using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Monads
{
    public class Class1
    {
        delegate T OnDemand<T>();

        static Nullable<T> CreateSimpleNullable<T>(T item) where T: struct
        {
            return new Nullable<T>(item);
        }

        static OnDemand<T> CreateOnDemand<T>(T item)
        {
            return () => item;
        }

        static IEnumerable<T> CreateSimpleSequence<T>(T item)
        {
            yield return item;
        }

        static Task<T> CreateSimpleTask<T>(T item)
        {
            return Task.FromResult(item);
        }

        static Lazy<T> CreateSimpleLazy<T>(T item)
        {
            return new Lazy<T>(() => item);
        }
    }
}