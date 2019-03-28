using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat();
            cat.MakeFriends(new Cat());

            var dog = new Dog();
            dog.MakeFriends(new Dog());

            // dog.MakeFriends(cat); - Fails to compile due to type safety
            
            var evilDog = new EvilDog();
            evilDog.MakeFriends(cat);

            var cat2 = new CatNoCrtp();
            var dog2 = new DogNoCrtp();

            cat2.MakeFriends(dog2); // Allowed since any Animal can be passed to MakeFriends

            Console.ReadLine();
        }
    }
}
