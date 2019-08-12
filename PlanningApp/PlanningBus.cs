using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Runtime.CompilerServices;

namespace PlanningApp
{
    public class PlanningBus : IBus
    {
        BindingList<Plan> _plans = null;
        private IDao _dao = null;
        private User _currentUser;

        public PlanningBus(IDao dao)
        {
            _dao = dao;
        }

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

        public BindingList<Plan> GetPlans()
        {
            return _currentUser != null ? _plans : null;
        } 

        public void AddNewPlan(Plan plan)
        {
            _plans?.Add(plan);
        }

        public void RemovePlan(int index)
        {
            _plans?.RemoveAt(index);
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

        public bool Login(User loginUser)
        {
            if (!_dao.checkUserExist(loginUser)) return false;
            _currentUser = loginUser;
            _plans = _dao.LoadPlans(_currentUser);
            return true;

        }

        public bool Signup(User signupUser)
        {
            return !_dao.checkUserExist(signupUser) && _dao.AddNewUser(signupUser);
        }

        public bool Logout()
        {
            _dao.SavePlans(_currentUser, _plans);
            _currentUser = null;
            return true;
        }
    }
}

