using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BillingManagement.UI.ViewModels.Commands
{
    class ChangeViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<string> _execute;

        public ChangeViewCommand(Action<string> action)
        {
            _execute = action;
        }

       /* public ChangeViewCommand(Action<string> execute, Predicate<string> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }*/

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as string);
        }
    }
}
