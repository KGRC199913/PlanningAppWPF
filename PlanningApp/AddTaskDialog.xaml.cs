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
            PriorityComboBox.ItemsSource = Enum.GetValues(typeof(PlanPriorityLevel));
            _plan = new Plan();
            _plan.EndDateTime = DateTime.Today;
            this.DataContext = _plan;
        }

        public AddTaskDialog(Plan plan)
        {
            InitializeComponent();
            PriorityComboBox.ItemsSource = Enum.GetValues(typeof(PlanPriorityLevel));
            _plan = plan;
            this.DataContext = _plan;
            CreateButton.Content = "Edit";
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
            if (TitleTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Title cannot be empty");
                return;
            }
            this.DialogResult = true;
        }

        private void AddTaskDialog_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
