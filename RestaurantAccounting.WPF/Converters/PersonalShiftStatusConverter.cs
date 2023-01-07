using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace RestaurantAccounting.WPF.Converters;

[ValueConversion(typeof(bool), typeof(string))]
public class PersonalShiftStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var shiftStatus = (bool)value!;
        return shiftStatus ? "Open" : "Closed";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}