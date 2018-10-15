using System;
using System.Collections;
using System.Collections.Generic;

namespace OO___Nulls.Common
{
    public class Option<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _content;

        private Option(IEnumerable<T> content)
        {
            _content = content;
        }

        public static Option<T> Some(T value) => new Option<T>(new [] { value });

        public static Option<T> None() => new Option<T>(new T[0]);

        public IEnumerator<T> GetEnumerator() => _content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public Option<T> When(Func<T, T> filter)
        //{

        //}
    }
}