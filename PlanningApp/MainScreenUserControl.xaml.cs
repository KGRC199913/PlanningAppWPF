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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanningApp
{
    /// <summary>
    /// Interaction logic for MainScreenUserControl.xaml
    /// </summary>
    public partial class MainScreenUserControl : UserControl
    {
        private Action _onSignOutSwapper;
        public MainScreenUserControl(Action swapperAction)
        {
            InitializeComponent();
            _onSignOutSwapper = swapperAction;

            ToDoListView.Items.Add(new Plan()
            {
                Title = "Meow",
                Detail = "Nya",
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today,
                IsDisable = false,
                PriorityLevel = PlanPriorityLevel.Emergence,
                State = PlanState.ToDo
            });
        }

        private void SignoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            var presenter = (this.DataContext as IPresentation);
            presenter?.SavePlans();
            _onSignOutSwapper?.Invoke();
        }
    }
}
