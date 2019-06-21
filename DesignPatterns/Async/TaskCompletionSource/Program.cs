using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskCompletionSource
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var tasks = new[] {
                Task.Delay(3000).ContinueWith(_ => 3),
                Task.Delay(1000).ContinueWith(_ => 1),
                Task.Delay(2000).ContinueWith(_ => 2),
                Task.Delay(5000).ContinueWith(_ => 5),
                Task.Delay(4000).ContinueWith(_ => 4),
            };
            //foreach (var bucket in tasks)
            //{
            //    var t = await bucket;
            //    //int result = await t;
            //    Console.WriteLine("{0}: {1}", DateTime.Now, t);
            //}

            //foreach (var task in tasks)
            //{
            //    var result = await task;
            //    Console.WriteLine(result);
            //}

            Console.WriteLine("Ordered:");

            foreach (var task in tasks.OrderByCompletion())
            {
                var result = await task;
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        public static async Task<int> DelayedInt(int delay)
        {
            await Task.Delay(delay);
            return delay;
        }
    }
}
