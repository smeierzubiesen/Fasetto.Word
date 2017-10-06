using System;
using System.Windows.Input;

namespace Fasetto.Word
{
    internal class RelayCommand : ICommand
    {
        #region private members

        private Action _mAction;

        #endregion private members

        #region Default constructor

        public RelayCommand(Action action)
        {
            _mAction = action;
        }

        #endregion Default constructor

        #region Command Methods

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _mAction();
        }

        #endregion Command Methods



        #region Public Events

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion Public Events
    }
}