using System.ComponentModel;

namespace PlanningApp
{
    public interface IDao
    {
        bool checkUserExist(User user);
        bool AddNewUser(User signupUser);
        BindingList<Plan> LoadPlans(User user);
        bool SavePlans(User user, BindingList<Plan> plans);
    }
}