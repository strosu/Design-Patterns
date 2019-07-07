using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = GeneratePrimes(20);
            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }

            Console.WriteLine("--------------------------");

            var primes2 = PrimesGenerator.GeneratePrimes(20);
            foreach (var prime in primes2)
            {
                Console.WriteLine(prime);
            }

            Console.ReadLine();
        }

        public static int[] GeneratePrimes(int maxValue)
        {
            if (maxValue >= 2)
            {
                int s = maxValue + 1;
                bool[] f = new bool[s];
                for (int i = 0; i < s; i++)
                {
                    f[i] = true;
                }

                f[0] = f[1] = false;

                for (int i = 2; i < Math.Sqrt(s) + 1; i++)
                {
                    if (f[i])
                    {
                        for (int j = 2 * i; j < s; j+=i)
                        {
                            f[j] = false;
                        }
                    }
                }

                int count = 0;
                for (int i = 0; i < s; i++)
                {
                    if (f[i]) count++;
                }

                int[] primes = new int[count];

                int k = 0;
                for (int i = 0; i < s; i++)
                {
                    if (f[i])
                    {
                        primes[k++] = i;
                    }
                }

                return primes;
            }
            else
            {
                return new int[0];
            }
        }
    }
}
