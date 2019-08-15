using System;
using System.Globalization;
using System.Windows.Data;

namespace PlanningApp
{
    public class StringPriorityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (PlanPriorityLevel) value;
            switch (data)
            {
                case PlanPriorityLevel.Low:
                    return "1";
                case PlanPriorityLevel.Normal:
                    return "2";
                case PlanPriorityLevel.High:
                    return "3";
                case PlanPriorityLevel.Important:
                    return "4";
                case PlanPriorityLevel.Emergence:
                    return "5";
                default:
                    return "1";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = int.Parse(value as string ?? throw new InvalidOperationException()) - 1;
            return (PlanPriorityLevel)data;
        }
    }
}