using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.WPF.Converters;

[ValueConversion(typeof(ShiftStatus), typeof(string))]
public class PersonalShiftStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var shiftStatus = (ShiftStatus)value!;
        return shiftStatus == ShiftStatus.Open ? "Open" : "Closed";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}