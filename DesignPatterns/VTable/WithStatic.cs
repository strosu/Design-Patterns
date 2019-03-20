using System;

namespace VTable
{
    public sealed class VTable
    {
        public readonly Action<StaticAnimal> Complain;
        public readonly Action<StaticAnimal> MakeNoise;

        public VTable(Action<StaticAnimal> complain, Action<StaticAnimal> makeNoise)
        {
            Complain = complain;
            MakeNoise = makeNoise;
        }
    }

    public abstract class StaticAnimal
    {
        public VTable VTable;

        public static void MakeNoiseMethod(StaticAnimal animal)
        {
            Console.WriteLine();
        }
    }

    public class StaticGiraffe : StaticAnimal
    {
        private static readonly VTable GiraffeVTable = new VTable(StaticGiraffe.ComplainMethod, StaticAnimal.MakeNoiseMethod);

        public bool Sore { get; set; }

        private static void ComplainMethod(StaticAnimal animal)
        {
            var tmp = (animal as StaticGiraffe).Sore ? "Blah" : "All good";
            Console.WriteLine(tmp);
        }

        public static StaticGiraffe Create()
        {
            var giraffe = new StaticGiraffe {VTable = GiraffeVTable};

            return giraffe;
        }
    }

    public class StaticCat : StaticAnimal
    {
        public bool Hungry { get; set; }
        private static readonly VTable CatVTable = new VTable(StaticCat.ComplainMethod, StaticCat.MakeNoiseMethod);

        private static void ComplainMethod(StaticAnimal animal)
        {
            var tmp = (animal as StaticCat).Hungry ? "Tuna" : "F off";
            Console.WriteLine(tmp);
        }

        private static void MakeNoiseMethod(StaticAnimal animal)
        {
            Console.WriteLine("meow");
        }

        public static StaticCat Create()
        {
            var cat = new StaticCat();
            cat.VTable = CatVTable;

            return cat;
        }
    }

    public class StaticDog : StaticAnimal
    {
        private static VTable DogVTable = new VTable(ComplainMethod, StaticAnimal.MakeNoiseMethod);
        public bool Small { get; set; }

        public static void ComplainMethod(StaticAnimal animal)
        {
            Console.WriteLine("TAXES");
        }

        public static void MakeNoise(StaticDog dog)
        {
            var tmp = dog.Small ? "zz" : "woof";
            Console.WriteLine(tmp);
        }

        public static StaticDog Create()
        {
            var dog = new StaticDog();
            dog.VTable = DogVTable;

            return dog;
        }
    }
}