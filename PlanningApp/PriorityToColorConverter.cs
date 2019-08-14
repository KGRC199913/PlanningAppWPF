using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PlanningApp
{
    public class PriorityToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (PlanPriorityLevel)value;
            switch (priority)
            {
                case PlanPriorityLevel.Low:
                    return Brushes.White;
                case PlanPriorityLevel.Normal:
                    return Brushes.WhiteSmoke;
                case PlanPriorityLevel.High:
                    return Brushes.LightYellow;
                case PlanPriorityLevel.Important:
                    return Brushes.Green;
                case PlanPriorityLevel.Emergence:
                    return Brushes.DarkRed;
                default:
                    return Brushes.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}