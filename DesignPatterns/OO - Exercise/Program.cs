using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO___Exercise
{
    class Program
    {
        static void Main2(string[] args)
        {
            Console.WriteLine(new Program().GetControlDigit(12345));

            Console.ReadLine();
        }

        int GetControlDigit(long number)
        {
            int sum = 0;
            bool isOddPos = true;

            while (number > 0)
            {
                int digit = (int) (number % 10);
                if (isOddPos)
                {
                    sum += 3 * digit;
                }
                else
                {
                    sum += digit;
                }

                number /= 10;
                isOddPos = !isOddPos;
            }

            return sum % 7;
        }
    }
}
