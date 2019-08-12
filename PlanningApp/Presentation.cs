using System.ComponentModel;

namespace PlanningApp
{
    public class Presentation : ViewModelBase, IPresentation
    {
        private IBus _bus = null;
        private BindingList<Plan> _displayPlans = new BindingList<Plan>();

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
    }
}