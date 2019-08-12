using System.ComponentModel;

namespace PlanningApp
{
    public interface IPresentation
    {
        BindingList<Plan> DisplayPlans { get; set; }
        User CurrentUser { get; }
        void Login();
        void Logout();
        void Signup();
    }
}