using System.ComponentModel;

namespace PlanningApp
{
    public interface IDao
    {
        bool CheckUserExist(User user);
        bool AddNewUser(User signupUser);
        bool UpdateUsersListInFile();
        BindingList<Plan> LoadPlans(User user);
        bool SavePlans(User user, BindingList<Plan> plans);
    }
}