using System;
using System.Collections.Generic;
using System.Linq;

namespace Functions
{
    public class PrimesGenerator
    {
        private static bool[] _crossedOut;

        public static List<int> GeneratePrimes(int maxValue)
        {
            if (maxValue < 2)
            {
                return new List<int>();
            }

            UnCrossUpTo(maxValue);
            CrossOutMultiples();
            return CopyPrimesToResult();
        }

        private static void UnCrossUpTo(int maxValue)
        {
            _crossedOut = new bool[maxValue + 1];
        }

        private static void CrossOutMultiples()
        {
            _crossedOut[0] = _crossedOut[1] = true;
            
            for (int i = 2; i < GetCrossOutLimit(); i++)
            {
                if (NotCrossed(i))
                {
                    CrossOutMultiplesOf(i);
                }
            }
        }

        private static void CrossOutMultiplesOf(int multiplier)
        {
            for (int j = 2 * multiplier; j < _crossedOut.Length; j += multiplier)
            {
                _crossedOut[j] = true;
            }
        }

        private static bool NotCrossed(int i)
        {
            return !_crossedOut[i];
        }

        private static int GetCrossOutLimit()
        {
            return (int) Math.Sqrt(_crossedOut.Length);
        }

        private static List<int> CopyPrimesToResult()
        {
            var result = new List<int>();
            for (int i = 0; i < _crossedOut.Length; i++)
            {
                if (!_crossedOut[i])
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}