using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Command.Commands
{
    public class RedoCommand : ICommand
    {
        private ICommand _redoneOperation;
        private readonly IList<ICommand> _currentList;

        public RedoCommand(IList<ICommand> currentList)
        {
            _currentList = currentList;
        }

        public void Execute()
        {
            _redoneOperation = _currentList.FirstOrDefault(x => x.Undone && x.Undoable());
            _redoneOperation?.Execute();
        }

        public void Undo()
        {
            _redoneOperation.Undo();
        }

        public bool Undone { get; set; }
    }
}