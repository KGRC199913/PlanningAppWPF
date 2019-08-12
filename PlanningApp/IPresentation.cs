using System.ComponentModel;

namespace PlanningApp
{
    public interface IPresentation
    {
        BindingList<Plan> DisplayPlans { get; set; }
    }
}