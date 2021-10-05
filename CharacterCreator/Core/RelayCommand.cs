using System;
using System.Windows.Input;

namespace CharacterCreator.Core
{
    public class RelayCommand : ObservableObject, ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public bool IsExecuting { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null || _canExecute(parameter);
            }
            catch (Exception ex)
            {
                DebugLogger.WriteLog(ex.Message, DebugLogger.LogLevel.ERROR);
                return false;
            }
        }

        public void Execute(object parameter)
        {
            try
            {
                IsExecuting = true;
                _execute(parameter);
            }
            catch (Exception ex)
            {
                DebugLogger.WriteLog(ex.Message, DebugLogger.LogLevel.ERROR);
            }
            finally
            {
                IsExecuting = false;
            }
        }
    }
}
