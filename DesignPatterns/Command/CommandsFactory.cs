using System;
using System.Collections.Generic;
using Command.Commands;

namespace Command
{
    public static class CommandsFactory
    {
        public static ICommand Build(IList<Square> currentSquares, IList<ICommand> currentCommands, params string[] args)
        {
            var command = args[0];
            switch (command)
            {
                case "C":
                    return new CreateCommand(currentSquares, int.Parse(args[1]), int.Parse(args[2]));
                case "M":
                    return new MoveCommand(currentSquares, int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]));
                case "U":
                    return new UndoCommand(currentCommands);
                case "R":
                    return new RedoCommand(currentCommands);
                case "P":
                    return new PrintCommand(currentSquares);
                default:
                    throw new ArgumentException("Bad operation");
            }
        }
    }
}