﻿namespace Command.Commands
{
    public interface ICommand
    {
        void Execute();

        void Undo();

        bool Undone { get; set; }
    }
}