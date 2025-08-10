using System;
using System.Windows.Input;

#nullable enable

namespace redwyre.Core.MVVM
{
    /// <summary>
    /// A simple implementation of the ICommand interface.
    /// </summary>
    [Serializable]
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public Action<object?> ExecuteAction { get; set; }
        public Func<object?, bool>? CanExecuteFunc { get; set; }

        public RelayCommand(Action<object?> executeAction, Func<object?, bool>? canExecuteFunc = null)
        {
            ExecuteAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            CanExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object? parameter)
        {
            return CanExecuteFunc != null ? CanExecuteFunc(parameter) : true;
        }

        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                ExecuteAction(parameter);
            }
        }

        public void RaiseCanExecuteChanged(object? sender = null)
        {
            CanExecuteChanged?.Invoke(sender, EventArgs.Empty);
        }
    }
}
