using System;

namespace VTable
{
    public abstract class Animal
    {
        public abstract void Complain();

        public virtual void MakeNoise()
        {
            Console.WriteLine("");
        }
    }

    public class Giraffe : Animal
    {
        public bool Sore { get; set; }

        public override void Complain()
        {
            var tmp = Sore ? "Blah" : "All good";
            Console.WriteLine(tmp);
        }
    }

    public class Cat : Animal
    {
        public bool Hungry { get; set; }

        public override void Complain()
        {
            var tmp = Hungry ? "Tuna" : "F off";
            Console.WriteLine(tmp);
        }

        public override void MakeNoise()
        {
            Console.WriteLine("meow");
        }
    }

    public class Dog : Animal
    {
        public bool Small { get; set; }

        public override void Complain()
        {
            Console.WriteLine("TAXES");
        }

        public new void MakeNoise()
        {
            var tmp = Small ? "zz" : "woof";
            Console.WriteLine(tmp);
        }
    }
}