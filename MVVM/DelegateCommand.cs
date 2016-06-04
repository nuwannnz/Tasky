using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tasky.MVVM
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {

        }
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}
