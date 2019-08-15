using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace PlanningApp
{
    public class StateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (BindingList<Plan>) value;
            PlanState targetState;
            switch ((string)parameter)
            {
                case "ToDo":
                    targetState = PlanState.ToDo;
                    break;
                case "Doing":
                    targetState = PlanState.Doing;
                    break;
                case "Done":
                    targetState = PlanState.Done;
                    break;
                default:
                    targetState = PlanState.Canceled;
                    break;
            }

            var returnData = data?.Where(x => x.State == targetState).ToList();
            return new BindingList<Plan>(returnData);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}