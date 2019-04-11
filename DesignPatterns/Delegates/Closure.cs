using System;

namespace Delegates
{
    public class Closure
    {
        public static Func<int, int> CloseArgument(int value)
        {
            int random = 100;
            Func<int, int> scale = x => value * x * random; // warning due to changing the value before the Func is invoked
            random = 99; // this is the value that will be used by the caller
            return scale;
        }
    }
}