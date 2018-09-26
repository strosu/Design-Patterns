using System;
using System.Collections.Generic;

namespace OO_Imutable
{
    class Program
    {
        private static bool IsHappyHour;

        static void Main(string[] args)
        {


            Buy(new MoneyAmount(12, "EUR"), 
                new MoneyAmount(10, "EUR"));

            Buy(new MoneyAmount(7, "EUR"),
                new MoneyAmount(10, "EUR"));


            IsHappyHour = true;

            Buy(new MoneyAmount(7, "EUR"),
                new MoneyAmount(10, "EUR"));

            var x = new MoneyAmount(2, "EUR");
            var y = new MoneyAmount(4, "EUR");

            if (x .Equals(y))
            {
                Console.WriteLine("Are equal");
            }

            if (x.Scale(2).Equals(y))
            {
                Console.WriteLine("Equal after scaling");
            }

            HashSet<MoneyAmount> set = new HashSet<MoneyAmount> {x.Scale(2), y};
            Console.WriteLine(set.Count);

            Console.ReadLine();
        }
        
        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1.0M;
            if (IsHappyHour)
            {
                factor = 0.5M;
            }

            Console.WriteLine($"Reserving and item that costs {cost}");
            return cost.Scale(factor);
        }

        private static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            var enoughMoney = wallet.Amount > cost.Amount;

            var finalCost = Reserve(cost);

            var finalEnough = wallet.Amount > finalCost.Amount;

            if (enoughMoney)
            {
                Console.WriteLine($"You will pay {cost} from your total of {wallet}");
            }
            else if (finalEnough)
            {
                Console.WriteLine($"This time, you will pay {finalCost} from your total of {wallet}");
            }
            else
            {
                Console.WriteLine($"You cannot pay {cost} from your total of {wallet}");
            }
        }
    }
}
