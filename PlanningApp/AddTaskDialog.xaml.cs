using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlanningApp
{
    /// <summary>
    /// Interaction logic for AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window, IReturnValue
    {
        private Plan _plan;
        public AddTaskDialog()
        {
            InitializeComponent();
            _plan = new Plan();
            this.DataContext = _plan;
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public object Value
        {
            get => _plan;
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void AddTaskDialog_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
