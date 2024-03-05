using System;
using System.Windows.Input;

namespace Calculator
{
    public class CustomCommand<T> : ICommand
    {
        private readonly Action<T> _action; 

        public CustomCommand(Action<T> action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action((T) parameter);
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}