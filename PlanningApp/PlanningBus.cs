using System;
using System.ComponentModel;

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

        ~PlanningBus()
        {
            if (_currentUser != null)
            {
                _dao.SavePlans(_currentUser, _plans);
            }

            _dao = null;
            _currentUser = null;
            _plans = null;
        }

        public BindingList<Plan> GetFilteredPlans(PlanFilterMode mode, object filterArg)
        {
            BindingList<Plan> filteredPlans = new BindingList<Plan>();
            switch (mode)
            {
                case PlanFilterMode.Content:
                {
                        var keyword = (string)filterArg;
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
                    var targetDate = (DateTime) filterArg;
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
                    var priority = (PlanPriorityLevel) filterArg;
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

        public void SettingSave()
        {
            throw new NotImplementedException();
        }

        public void DataSave()
        {
            if (_currentUser == null) return;
            _dao.SavePlans(_currentUser, _plans);
        }

        public bool Login(User loginUser)
        {
            if (!_dao.CheckUserValid(loginUser)) return false;
            _currentUser = loginUser;
            _plans = _dao.LoadPlans(_currentUser);
            return true;
        }

        public bool Signup(User signupUser)
        {
            return !_dao.CheckUserExist(signupUser) && _dao.AddNewUser(signupUser);
        }

        public bool Logout()
        {
            _dao.SavePlans(_currentUser, _plans);
            _currentUser = null;
            _plans = null;
            return true;
        }
    }
}

