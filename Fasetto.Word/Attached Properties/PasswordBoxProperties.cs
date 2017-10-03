// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PasswordBoxProperties.cs" company="mitos[dash]kalandiel">
//   
// </copyright>
// <summary>
//   PasswordBox Properties to determine if the password box has a password typed in
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fasetto.Word
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// PasswordBox Properties to determine if the password box has a password typed in
    /// </summary>
    public class PasswordBoxProperties
    {
        /// <summary>
        /// The HasText property as a <see cref="DependencyProperty"/>
        /// </summary>
        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

        /// <summary>
        /// Monitor if a password box has been changed
        /// </summary>
        public static readonly DependencyProperty MonitorPasswordProperty =
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

        /// <summary>
        /// The event that gets fired when a password box property gets changed.
        /// </summary>
        /// <param name="d">
        /// The <see cref="DependencyObject"/>
        /// </param>
        /// <param name="e">
        /// The <see cref="DependencyPropertyChangedEventArgs"/> argument(s).
        /// </param>
        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = (PasswordBox)d;
            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                SetHasText(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// This event gets fired when a password box changes
        /// </summary>
        /// <param name="sender">
        /// The <see cref="sender"/> of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs"/> arguments.
        /// </param>
        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText((PasswordBox)sender);
        }

        /// <summary>
        /// Set HasText property
        /// </summary>
        /// <param name="element">
        /// The password box affected
        /// </param>
        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        /// <summary>
        /// Set the value of PasswordBox has changed
        /// </summary>
        /// <param name="element">
        /// TODO The element.
        /// </param>
        /// <param name="value">
        /// A <see cref="bool"/> to set whether PasswordBox has changed.
        /// </param>
        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        /// <summary>
        /// Get HasText property for the password box as a <see cref="DependencyProperty"/>
        /// </summary>
        /// <param name="element">
        /// The password box affected
        /// </param>
        /// <returns>
        /// The value of HasText as a <see cref="bool"/>.
        /// </returns>
        // ReSharper disable once StyleCop.SA1202
        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }

        /// <summary>
        /// Get the value of PasswordBox has changed
        /// </summary>
        /// <param name="element">
        /// The password box in question
        /// </param>
        /// <returns>
        /// The result of the fact whether password box has changed as a <see cref="bool"/>.
        /// </returns>
        // ReSharper disable once StyleCop.SA1202
        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }
    }
}
