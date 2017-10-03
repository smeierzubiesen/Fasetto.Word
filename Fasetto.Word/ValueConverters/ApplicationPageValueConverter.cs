using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.Word
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                switch ((ApplicationPage) value)
                {
                    case ApplicationPage.Login:
                        return new LoginPage();
                    default:
                        Debugger.Break();
                        return null;
                }
            else
            {
                return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
