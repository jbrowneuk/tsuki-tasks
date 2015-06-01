namespace TodoList.ViewModel
{
    using System;
    using System.Windows.Input;

    internal sealed class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;


        /// <summary>
        /// Creates an instance of the DelegateCommand which runs the specified action when called.
        /// </summary>
        /// <param name="execute">Action to call</param>
        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        /// <summary>
        /// TODO: needs an implementation of CanExecute that isn't "return true".
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <inheritdoc />
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}