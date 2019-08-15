using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PlanningApp
{
    public class StateArrowVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var planState = (PlanState) value;
            var arrowDirection = int.Parse(parameter as string);
            switch (arrowDirection)
            {
                // 0 is left
                case 0:
                    return planState == PlanState.ToDo ? Visibility.Hidden : Visibility.Visible;
                // 1 is right
                case 1 when planState == PlanState.Done:
                    return Visibility.Hidden;
                case 1:
                    return Visibility.Visible;
                default:
                    return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}