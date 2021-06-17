using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CharacterCreator.Classes.CommonObject
{
    public class BasicCommand : ICommand
    {

        private readonly Action<object> executeHandler;
        private readonly Func<object, bool> canExecuteHandler;
        public event EventHandler CanExecuteChanged;

        public BasicCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("Execute cannot be null");
            }
            executeHandler = execute;
            canExecuteHandler = canExecute;

        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteHandler == null)
            {
                return true;
            }
            return canExecuteHandler(parameter);
        }

        public void Execute(object parameter)
        {
            executeHandler(parameter);
        }
    }
}
