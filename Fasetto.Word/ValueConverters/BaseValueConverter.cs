using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasetto.Word
{
    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of the value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private members

        /// <summary>
        /// A single static instance of the converter
        /// </summary>
        private static T _converter = null;

        #endregion

        #region Markup Extension Methods

        /// <summary>
        /// Provides a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns>A static instance of the converter</returns>
        public override Object ProvideValue(IServiceProvider serviceProvider) => _converter ?? (_converter = new T());

        #endregion

        #region Value Converter Methods

        /// <inheritdoc />
        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="targetType">The type to convert to</param>
        /// <param name="parameter">Any parameters passed into the converter</param>
        /// <param name="culture">The language culture (if any) to use</param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <inheritdoc />
        /// <summary>
        /// The method to convert a value back to its origin type
        /// </summary>
        /// <param name="value">The value to convert back</param>
        /// <param name="targetType">The type to convert back to</param>
        /// <param name="parameter">Any parameters passed into the converter</param>
        /// <param name="culture">The language culture (if any) to use</param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
