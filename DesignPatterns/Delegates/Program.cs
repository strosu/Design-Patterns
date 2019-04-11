using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        private delegate T Transform<T>(T x);

        private delegate bool IsGood(string x);

        delegate void Do1();
        delegate void Do2();

        static void Main(string[] args)
        {
            var func = Closure.CloseArgument(11);
            int value = 20; // "value" is closed over in CloseArgument's scope 
            Console.WriteLine(func(20));

            Transform<int> del = TransformFunc;
            Transform<bool> del2 = IsGoodFunc; 
            Transform<int> del3 = TransformFunc2;
            del += del3;
            //del += del2; // Fails due to type mismatch

            Console.WriteLine(del.Invoke(11));

            Do1 do1 = () => Console.WriteLine("called d1");
            Do2 do2;
            //do2 = do1; // incompatible
            //do2 = (Do2) do1; // incompatible
            do2 = new Do2(do1);

            do1();
            do2();

            Console.ReadLine();
        }

        private static int TransformFunc(int x)
        {
            var res = x * 2;
            Console.WriteLine(res);
            return res;
        }

        private static int TransformFunc2(int x)
        {
            var res = x * 3;
            Console.WriteLine(res);
            return res;
        }

        private static bool IsGoodFunc(bool x)
        {
            return false;
        }
    }
}
