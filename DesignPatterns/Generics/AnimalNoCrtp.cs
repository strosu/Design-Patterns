using System;

namespace Generics
{
    public class AnimalNoCrtp
    {
        public virtual void MakeFriends(AnimalNoCrtp animal)
        {
            Console.WriteLine($"A type of {MyType()} Made friends with {typeof(AnimalNoCrtp)}");
        }

        private string MyType()
        {
            return this.GetType().ToString();
        }
    }

    public class CatNoCrtp : AnimalNoCrtp
    {
        public override void MakeFriends(AnimalNoCrtp animal)
        {
            base.MakeFriends(animal);
        }
    }

    public class DogNoCrtp : AnimalNoCrtp
    {
        public override void MakeFriends(AnimalNoCrtp animal)
        {
            base.MakeFriends(animal);
        }
    }
}