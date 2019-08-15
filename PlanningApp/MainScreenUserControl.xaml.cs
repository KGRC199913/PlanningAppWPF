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
        }

        private void SignoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            var presenter = (this.DataContext as IPresentation);
            presenter?.SavePlans();
            _onSignOutSwapper?.Invoke();
        }

        private void ToDoListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            ToDoListView.DataContext = this.DataContext;
        }

        private void DoingListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            DoingListView.DataContext = this.DataContext;
        }

        private void DoneListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            DoneListView.DataContext = this.DataContext;
        }
    }
}
