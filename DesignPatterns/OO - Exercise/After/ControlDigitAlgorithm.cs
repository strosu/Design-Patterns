using System;
using System.Collections.Generic;
using System.Linq;

namespace OO___Exercise.After
{
    public class ControlDigitAlgorithm
    {
        private readonly Func<long, IEnumerable<int>> _digitFunc;
        private readonly IEnumerable<int> _factors;
        private readonly int _modulo;

        public ControlDigitAlgorithm(Func<long, IEnumerable<int>> digitFunc, IEnumerable<int> factors, int modulo)
        {
            _digitFunc = digitFunc;
            _factors = factors;
            _modulo = modulo;
        }

        public int GetControlDigit(long number) 
            => _digitFunc(number)
                   .Zip(_factors, (x, y) => x * y)
                   .Sum()
               % _modulo;
    }
}