using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Runtime.CompilerServices;

namespace PlanningApp
{
    public class PlanningBus : IBus
    {
        BindingList<Plan> _plans = new BindingList<Plan>();
        private IDao _dao;

        public BindingList<Plan> GetFilteredPlans(PlanFilterMode mode, object filterArg)
        {
            BindingList<Plan> filteredPlans = new BindingList<Plan>();
            switch (mode)
            {
                case PlanFilterMode.Content:
                {
                        string keyword = (string)filterArg;
                        foreach (var it in _plans)
                        {
                            if (it.Detail.Contains(keyword))
                            {
                                filteredPlans.Add(it);
                            }
                        }
                }
                    break;
                case PlanFilterMode.Date:
                {
                    DateTime targetDate = (DateTime) filterArg;
                    foreach (var it in _plans)
                    {
                        if (it.EndDateTime.Equals(targetDate) || it.StartDateTime.Equals(targetDate))
                        {
                            filteredPlans.Add(it);
                        }
                    }
                }
                    break;
                case PlanFilterMode.Priority:
                {
                    PlanPriorityLevel priority = (PlanPriorityLevel) filterArg;
                    foreach (var it in _plans)
                    {
                        if (it.PriorityLevel == priority)
                        {
                            filteredPlans.Add(it);
                        }
                    }
                }
                    break;
                default:
                    break;
            }

            return filteredPlans;
        }

        public BindingList<Plan> GetPlans() => _plans;

        public void AddNewPlan(Plan plan)
        {
            _plans.Add(plan);
        }

        public void RemovePlan(int index)
        {
            _plans.RemoveAt(index);
        }

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void Import()
        {
            throw new NotImplementedException();
        }

        public void SettingSave()
        {
            throw new NotImplementedException();
        }

        public void SettingLoad()
        {
            throw new NotImplementedException();
        }

        public void DataSave()
        {
            throw new NotImplementedException();
        }

        public void DataLoad()
        {
            throw new NotImplementedException();
        }
    }
}

