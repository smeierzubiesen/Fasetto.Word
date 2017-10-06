// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="mitos[dash]kalandiel">
//   2017 by AngelSix - modified by mitos[dash]kalandiel
// </copyright>
// <summary>
//   A base view model that fires PropertyChanged as required
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fasetto.Word
{
    using System.ComponentModel;

    /// <summary>
    /// A base view model that fires PropertyChanged as required
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Public Events

        /// <summary>
        /// The event that is fired when a child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion Public Events



        #region Public Methods

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name">The name of the changed property</param>
        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion Public Methods

        #region Command Helper

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) then the <see cref="Action"/> wont be triggered.
        /// If the flag is false (indicating no running function) then the <see cref="Action"/> is triggered and run.
        /// Once the <see cref="Action"/> is finished, if it was run, then the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag">The <see cref="bool"/> property flag defining if the command is already running.</param>
        /// <param name="action">the <see cref="Action"/> to trigger in case the flag is false.</param>
        /// <returns>The <see cref="Task"/> status</returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //Check if the flag property is true, meaning the function is running
            if (updatingFlag.GetPropertyValue())
                return;

            //Set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                //set the property flag back to false, as it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion Command Helper
    }
}