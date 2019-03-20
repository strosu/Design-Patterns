using System;

namespace VTable
{
    class Program
    {
        static void Main(string[] args)
        {

            Animal animal = new Giraffe();
            animal.Complain();
            animal.MakeNoise();

            animal = new Cat();
            animal.Complain();
            animal.MakeNoise();

            Dog dog = new Dog();
            dog.Complain();
            dog.MakeNoise();

            animal = dog;
            animal.Complain();
            animal.MakeNoise();

            Console.WriteLine("------------------------STATIC NEXT");

            //StaticAnimal animal2 = StaticGiraffe.Create();
            //animal2.Complain(animal2);
            //animal2.MakeNoise(animal2);

            //animal2 = StaticCat.Create();
            //animal2.Complain(animal2);
            //animal2.MakeNoise(animal2);

            //StaticDog dog2 = StaticDog.Create();
            //dog2.Complain(dog2);
            //StaticDog.MakeNoise(dog2);

            //animal2 = dog2;
            //animal2.Complain(animal2);
            //animal2.MakeNoise(animal2);

            StaticAnimal animal2 = StaticGiraffe.Create();
            animal2.VTable.Complain(animal2);
            animal2.VTable.MakeNoise(animal2);

            animal2 = StaticCat.Create();
            animal2.VTable.Complain(animal2);
            animal2.VTable.MakeNoise(animal2);

            StaticDog dog2 = StaticDog.Create();
            dog2.VTable.Complain(dog2);
            StaticDog.MakeNoise(dog2);

            animal2 = dog2;
            animal2.VTable.Complain(animal2);
            animal2.VTable.MakeNoise(animal2);

            Console.ReadLine();
        }
    }
}
