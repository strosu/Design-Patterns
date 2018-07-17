using System;
using System.Collections.Generic;

namespace Command.Commands
{
    public class PrintCommand : ICommand
    {
        private readonly IList<Square> _currentList;

        public PrintCommand(IList<Square> currentList)
        {
            _currentList = currentList;
        }

        public void Execute()
        {
            foreach (var square in _currentList)
            {
                Console.WriteLine($"Square {square.Id} is at position {square.X} and {square.Y} and has length {square.Length}");
            }
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }

        public bool Undone { get; set; }
    }
}