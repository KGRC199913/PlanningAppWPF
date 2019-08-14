using System.ComponentModel;
using System.Windows.Forms;

namespace PlanningApp
{
    public interface IPresentation
    {
        BindingList<Plan> DisplayPlans { get; set; }
        User CurrentUser { get; }
        bool Login(User user);
        void Logout();
        void Signup();
        void ShowNotification(int timeout, string title, string message, string typeIcon);
        void SavePlans();
    }
}