using System.Collections.Generic;
using System.Linq;

namespace Command.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly int _j;
        private readonly int _k;
        private readonly Square _previous;

        public bool Undone { get; set; }

        public MoveCommand(IList<Square> currentList, int id, int j, int k)
        {
            _previous = currentList.FirstOrDefault(x => x.Id == id);
            _j = j;
            _k = k;
        }

        public void Execute()
        {
            Undone = false;
            if (_previous == null)
            {
                return;
            }

            _previous.X += _j;
            _previous.Y += _k;
        }

        public void Undo()
        {
            Undone = true;

            if (_previous == null)
            {
                return;
            }

            _previous.X -= _j;
            _previous.Y -= _k;
        }
    }
}