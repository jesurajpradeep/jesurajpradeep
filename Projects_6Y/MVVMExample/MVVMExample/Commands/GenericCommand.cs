using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMExample.Commands
{
    class GenericCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        public GenericCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public GenericCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Execute");
            }

            _execute = execute;

            _canExecute = canExecute;
        }


        #region ICommand Members

        /// <summary>
        /// Checks the command executability
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Notifies CanExecute event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
           add { CommandManager.RequerySuggested += value; }

           remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        ///	Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }

        #endregion

    }
}
