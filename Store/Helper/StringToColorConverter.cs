using System.Globalization;

namespace Store.Helper;
public class StringToColorConverter : IValueConverter
{
    [Obsolete]
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Color color = new Color(0, 0, 0, 0);
        if (value is not string str || string.IsNullOrEmpty(str) || str == "transparent")
        {
            return color;
        }
        
        try
        {
            color = Color.FromHex(str[0] != '#' ? $"#{str}" : str);
        }
        catch (Exception)
        {
            return color;
        }
        return color;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}