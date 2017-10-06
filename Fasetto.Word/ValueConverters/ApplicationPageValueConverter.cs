namespace Fasetto.Word
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// Convert an <see cref="ApplicationPage"/> to value of a Page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        #region Public Methods

        /// <summary>
        /// Convert an <see cref="ApplicationPage"/> to an <see cref="object"/> containing the actual PageValue
        /// </summary>
        /// <param name="value">The <see cref="ApplicationPage"/> value to convert</param>
        /// <param name="targetType">The <see cref="Type"/> to convert to</param>
        /// <param name="parameter">Any parameter passed through</param>
        /// <param name="culture">The language <see cref="CultureInfo"/>.</param>
        /// <returns>The <see cref="object"/> containing an actual page.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                switch ((ApplicationPage)value)
                {
                    case ApplicationPage.Login:
                        return new LoginPage();

                    case ApplicationPage.Chat:
                        return new ChatPage();

                    default:
                        Debugger.Break();
                        return null;
                }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (Not implemented!) Convert the page back to an <see cref="ApplicationPage"/>.
        /// </summary>
        /// <param name="value">The page to convert back.</param>
        /// <param name="targetType">The <see cref="Type"/> to convert back to</param>
        /// <param name="parameter">Any parameter passed through</param>
        /// <param name="culture">The language <see cref="CultureInfo"/>.</param>
        /// <returns>An <see cref="ApplicationPage"/> value.</returns>
        /// <exception cref="NotImplementedException">We don't need this function, thus its not implemented.</exception>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}