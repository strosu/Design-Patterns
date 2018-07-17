using System.Collections.Generic;
using System.Linq;

namespace Command.Commands
{
    public class UndoCommand : ICommand
    {
        private readonly IList<ICommand> _currentList;
        private ICommand _undoneOperation;

        public UndoCommand(IList<ICommand> currentList)
        {
            _currentList = currentList;
        }

        public void Execute()
        {
            _undoneOperation = _currentList.LastOrDefault(x => !x.Undone && x.Undoable());
            _undoneOperation?.Undo();
        }

        public void Undo()
        {
            _undoneOperation?.Execute();
        }

        public bool Undone { get; set; } = true;
    }

    public static class Extension
    {
        public static bool Undoable(this ICommand command)
        {
            return command is MoveCommand || command is CreateCommand;
        }
    }
}