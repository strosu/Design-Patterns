using System;
using System.Collections.Generic;
using ChainOfCommand.Cards;

namespace ChainOfCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp1 = new ApprovalHandler(new Employee("1", decimal.Zero));
            var emp2 = new ApprovalHandler(new Employee("2", 2000));
            var emp3 = new ApprovalHandler(new Employee("3", 5000));
            var emp4 = new ApprovalHandler(new Employee("4", 20000));

            emp1.AddNext(emp2);
            emp2.AddNext(emp3);
            emp3.AddNext(emp4);

            //var ammount = decimal.Parse(Console.ReadLine());
            //Console.WriteLine(emp1.Approve(ammount));

            //Console.ReadLine();

            var evaluator = EvaluatorConfigurator.Build();

            var royal = new Hand(new List<Card>()
            {
                new Card
                {
                    Value = 10,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 11,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 12,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 13,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 14,
                    Color = Color.Club
                },
            });

            var straightFlush = new Hand(new List<Card>()
            {
                new Card
                {
                    Value = 10,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 11,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 12,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 13,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 9,
                    Color = Color.Club
                },
            });

            var four = new Hand(new List<Card>()
            {
                new Card
                {
                    Value = 10,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 10,
                    Color = Color.Diamond
                },
                new Card
                {
                    Value = 12,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 10,
                    Color = Color.Heart
                },
                new Card
                {
                    Value = 10,
                    Color = Color.Spade
                },
            });

            var three = new Hand(new List<Card>()
            {
                new Card
                {
                    Value = 10,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 11,
                    Color = Color.Diamond
                },
                new Card
                {
                    Value = 12,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 10,
                    Color = Color.Heart
                },
                new Card
                {
                    Value = 10,
                    Color = Color.Spade
                },
            });

            var twoPairs = new Hand(new List<Card>()
            {
                new Card
                {
                    Value = 10,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 10,
                    Color = Color.Diamond
                },
                new Card
                {
                    Value = 12,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 9,
                    Color = Color.Heart
                },
                new Card
                {
                    Value = 9,
                    Color = Color.Spade
                },
            });

            var nada = new Hand(new List<Card>()
            {
                new Card
                {
                    Value = 1,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 2,
                    Color = Color.Diamond
                },
                new Card
                {
                    Value = 4,
                    Color = Color.Club
                },
                new Card
                {
                    Value = 9,
                    Color = Color.Heart
                },
                new Card
                {
                    Value = 7,
                    Color = Color.Spade
                },
            });

            Console.WriteLine(evaluator.Evaluate(royal));
            Console.WriteLine(evaluator.Evaluate(straightFlush));
            Console.WriteLine(evaluator.Evaluate(four));
            Console.WriteLine(evaluator.Evaluate(three));
            Console.WriteLine(evaluator.Evaluate(twoPairs));
            Console.WriteLine(evaluator.Evaluate(nada));


            Console.ReadLine();
        }
    }
}
