using System.Globalization;

namespace Store.Helper;
public class StringToBoolConverter : IValueConverter
{
    [Obsolete]
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        
        if (value is not string str || string.IsNullOrEmpty(str) || str == "0")
        {
            return false;
        }

       
        return true;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}