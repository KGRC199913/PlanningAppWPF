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

        public bool Login(User user)
        {
            if (_bus?.Login(user) == true)
            {
                _displayPlans = _bus.GetPlans();
                return true;
            }
            return false;
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

        public void SavePlans()
        {
            _bus.DataSave();
        }
    }
}