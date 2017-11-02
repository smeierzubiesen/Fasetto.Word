using System;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The relay command class that handles actions in our MVVM app.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region private members

        /// <summary>
        /// Private variable holding the action to relay
        /// </summary>
        private Action mAction;

        #endregion private members

        #region Default constructor

        /// <summary>
        /// RelayCommand constructor (also see: <see cref="RelayCommand"/>)
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion Default constructor

        #region Command Methods

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter">The parameter for the action to be taken</param>
        /// <returns>Always true</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Execute the action in question
        /// </summary>
        /// <param name="parameter">The parameter for the action</param>
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion Command Methods



        #region Public Events

        /// <inheritdoc/>
        /// <summary>
        /// The event thats fired when the <see
        /// cref="M:Fasetto.Word.Core.RelayCommand.CanExecute(System.Object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion Public Events
    }
}