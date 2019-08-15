using System.ComponentModel;

namespace PlanningApp
{
    public enum PlanFilterMode
    {
        Content,
        Date,
        Priority
    }

    public interface IBus
    {
        BindingList<Plan> GetFilteredPlans(PlanFilterMode mode, object filterArg);
        BindingList<Plan> GetPlans();
        void AddNewPlan(Plan plan);
        void RemovePlan(Plan sample);
        void SettingSave(); // TEMP
        void DataSave(); // TEMP
        bool Login(User loginUser);
        bool Signup(User signupUser);
        bool Logout();
    }
}