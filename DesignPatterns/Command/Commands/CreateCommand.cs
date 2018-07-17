using System.Collections.Generic;
using System.Linq;

namespace Command.Commands
{
    public class CreateCommand : ICommand
    {
        private readonly Square _previous;
        private readonly IList<Square> _currentList;
        private readonly int _id;
        private readonly int _length;
        public bool Undone { get; set; }
        private Square _added;

        public CreateCommand(IList<Square> currentList, int id, int length)
        {
            _previous = currentList.FirstOrDefault(x => x.Id == id);
            _currentList = currentList;
            _id = id;
            _length = length;
            _added = CreateNewOrReset();
        }

        public void Execute()
        {
            if (_previous == null)
            {
                _currentList.Add(_added);
            }
            else
            {
                int index = _currentList.IndexOf(_previous);
                _currentList[index] = _added;
            }

            Undone = false;
        }

        public void Undo()
        {
            if (_previous == null)
            {
                _currentList.Remove(_added);
            }
            else
            {
                int index = _currentList.IndexOf(_added);
                _currentList[index] = _previous;
            }

            Undone = true;
        }

        private Square CreateNewOrReset()
        {
            return new Square()
            {
                Id = _id,
                Length = _length
            };
        }
    }
}