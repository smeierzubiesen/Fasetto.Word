/*! \mainpage Fasetto.Word Documentation
 *
 * \section intro_sec Introduction
 *
 * Fasetto.Word is an ongoing project to learn C# and WPF/XAML
 *
 * \section install_sec Installation
 *
 * \subsection step1 Step 1: Unzip
 *
 * Unzip the file anywhere
 *
 * \subsection step2 Step 2: Execute
 *
 * Simply doubleclick the .exe file and it will run
 */

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="mitos[dash]kalandiel">
//     2017 by AngelSix - modified by mitos[dash]kalandiel
// </copyright>
// <summary>
// Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fasetto.Word
{
    using Fasetto.Word.Core;
    using System.Windows;

    /// <inheritdoc/>
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Protected Methods

        /// <summary>
        /// What do we during the OnStartup event for the application.
        /// </summary>
        /// <param name="e">event argument(s)</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the base appliation do what it needs to do
            base.OnStartup(e);

            // Setup the IoC
            IoC.Setup();

            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        #endregion Protected Methods
    }
}