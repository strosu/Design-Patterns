using System;
using System.Collections.Generic;
using System.Linq;
using Command.Commands;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareList = new List<Square>();
            var commandList = new List<ICommand>();

            while (true)
            {
                var items = Console.ReadLine().Split(' ').ToArray();
                var command = CommandsFactory.Build(squareList, commandList, items);
                commandList.Add(command);
                command.Execute();
            }
        }
    }
}
