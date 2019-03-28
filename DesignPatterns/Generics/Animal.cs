using System;

namespace Generics
{
    public class Animal<T> where T : Animal<T>
    {
        public virtual void MakeFriends(T animal)
        {
            Console.WriteLine($"A type of {MyType()} Made friends with {typeof(T)}");
        }

        private string MyType()
        {
            return this.GetType().ToString();
        }
    }

    public class Cat : Animal<Cat>
    {
        public override void MakeFriends(Cat animal)
        {
            base.MakeFriends(animal);
        }

        // Doesn't compile due to type safety
        // Method MakeFriends needs to take an argument of the same type as the overriding class
        //public override void MakeFriends(Animal<Dog> animal)
        //{

        //}
    }

    public class Dog : Animal<Dog>
    {
        public override void MakeFriends(Dog animal)
        {
            base.MakeFriends(animal);
        }
    }

    public class EvilDog : Animal<Cat>
    {
        public override void MakeFriends(Cat animal)
        {
            base.MakeFriends(animal);
        }
    }
}