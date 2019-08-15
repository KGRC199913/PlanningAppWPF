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

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text.Equals(string.Empty)) return;
            (this.DataContext as IPresentation)?.FilterPlansByContent(SearchTextBox.Text);
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var AddDialog = new AddTaskDialog();
            if (AddDialog.ShowDialog() != true) return;
            var planReturned = AddDialog.Value as Plan;
            if (planReturned == null) return;
            planReturned.State = PlanState.ToDo;
            (this.DataContext as IPresentation)?.AddPlan(planReturned);
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox.Text.Equals(string.Empty))
            {
                (this.DataContext as IPresentation)?.ShowAllPlans();
            }
        }
    }
}
