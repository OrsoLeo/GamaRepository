using System;
using System.Windows.Input;

namespace CommandLibrary
{
    public class RelayCommand : ICommand
    {
        readonly Predicate<object> _canExecute;
        readonly Action<object> _execute;
        public RelayCommand(Action<object> _ex, Predicate<object> _canEx = null)
        {
            _execute = _ex;
            _canExecute = _canEx;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
