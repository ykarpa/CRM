// <copyright file="RelayCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.Core
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Predicate<object> canExec, Action<object> exec)
        {
            this._canExecute = canExec;
            this._execute = exec;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return this._canExecute(parameter!);
        }

        void ICommand.Execute(object? parameter)
        {
            this._execute(parameter!);
        }
    }
}
