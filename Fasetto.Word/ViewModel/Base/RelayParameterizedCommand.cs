namespace Fasetto.Word
{
    using System;
    using System.Windows.Input;

    /// <inheritdoc />
    public class RelayParameterizedCommand : ICommand
    {
        #region private members

        /// <summary>
        /// The action to execute
        /// </summary>
        private Action<object> Action;

        #endregion

        #region Default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayParameterizedCommand"/> class.
        /// </summary>
        /// <param name="action">
        /// TODO The action.
        /// </param>
        public RelayParameterizedCommand(Action<object> action)
        {
            this.Action = action;
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter">The parameter for the command</param>
        /// <returns>A boolean of the actions success</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="parameter">The parameter for the command</param>
        public void Execute(object parameter)
        {
            this.Action(parameter);
        }
        #endregion

        #region Public Events
        /// <summary>
        /// The event that's fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender,e) => { };
        #endregion
    }
}
