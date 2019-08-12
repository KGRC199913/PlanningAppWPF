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
        void RemovePlan(int index);
        void Export(); // TEMP
        void Import(); // TEMP
        void SettingSave(); // TEMP
        void SettingLoad(); // TEMP
        void DataSave(); // TEMP
        void DataLoad(); // TEMP
        bool Login(User loginUser);
        bool Signup(User signupUser);
        bool Logout();
    }
}