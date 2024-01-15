using System.Globalization;

namespace Store.Helper
{
    public class ImageUrlResizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string iconUrl)
            {
                if (parameter is not null)
                {
                    return $"{iconUrl}?blur={parameter}";
                }
              
                return $"{iconUrl}?w=170";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

