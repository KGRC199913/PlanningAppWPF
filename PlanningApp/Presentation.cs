using System.ComponentModel;

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

        public User CurrentUser {
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
    }
}