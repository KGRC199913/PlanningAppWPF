using System.ComponentModel;
using System.Windows.Forms;

namespace PlanningApp
{
    public interface IPresentation
    {
        BindingList<Plan> DisplayPlans { get; set; }
        User CurrentUser { get; }
        void Login();
        void Logout();
        void Signup();
        void ShowNotification(int timeout, string title, string message, string typeIcon);
    }
}