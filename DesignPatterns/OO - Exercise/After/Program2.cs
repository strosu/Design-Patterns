using OO___Exercise.After;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OO___Exercise
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ControlDigitAlgorithms.ForFinance.GetControlDigit(12345));
            Console.WriteLine(ControlDigitAlgorithms.ForLegal.GetControlDigit(12345));

            Console.ReadLine();
        }
    }
}
