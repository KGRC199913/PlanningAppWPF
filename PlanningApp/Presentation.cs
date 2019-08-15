using System;
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

        public void AddPlan(Plan plan)
        {
            _bus.AddNewPlan(plan);
            DisplayPlans = _bus.GetPlans();
        }

        public bool Login(User user)
        {
            if (_bus?.Login(user) != true) return false;
            _displayPlans = _bus.GetPlans();
            _currentUser = user;
            return true;
        }

        public void Logout()
        {
            _displayPlans = new BindingList<Plan>();
            _currentUser = null;
        }

        public bool Signup(User signupUser)
        {
            return _bus?.Signup(signupUser) == true;
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