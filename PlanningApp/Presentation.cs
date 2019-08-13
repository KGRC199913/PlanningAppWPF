using System.ComponentModel;
using System.Windows.Forms;

namespace PlanningApp
{
    public class Presentation : ViewModelBase, IPresentation
    {
        private IBus _bus = null;
        private BindingList<Plan> _displayPlans = new BindingList<Plan>();
        private User _currentUser;

        public Presentation(IBus bus)
        {
            _bus = bus;
        }

        public BindingList<Plan> DisplayPlans
        {
            get => _displayPlans;
            set
            {
                _displayPlans = value;
                OnPropertyChanged();
            }
        }

        public User CurrentUser
        {
            get => _currentUser;
        }

        public void Login()
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public void Signup()
        {
            throw new System.NotImplementedException();
        }

        public void ShowNotification(int timeout, string title, string message, string typeIcon)
        {
            App.ShowNotification(timeout, title, message, typeIcon);
        }
    }
}