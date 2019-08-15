using System.ComponentModel;
using System.Windows.Forms;

namespace PlanningApp
{
    public interface IPresentation
    {
        BindingList<Plan> DisplayPlans { get; set; }
        User CurrentUser { get; }
        void AddPlan(Plan plan);
        void RemovePlan(Plan plan);
        void ShowAllPlans();
        void FilterPlansByContent(string content);
        bool Login(User user);
        void Logout();
        bool Signup(User signupUser);
        void ShowNotification(int timeout, string title, string message, string typeIcon);
        void SavePlans();
    }
}