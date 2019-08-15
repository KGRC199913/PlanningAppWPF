using System;

namespace PlanningApp
{
    public enum PlanPriorityLevel
    {
        Low,
        Normal,
        High,
        Important,
        Emergence
    }

    public enum PlanState
    {
        ToDo,
        Doing,
        Done,
        Canceled
    }

    [Serializable]
    public class Plan : ViewModelBase
    {
        private string _title;
        private string _detail;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private PlanPriorityLevel _priorityLevel;
        private PlanState _state;
        private bool _isDisable;

        public string Detail
        {
            get => _detail;
            set
            {
                _detail = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDateTime
        {
            get => _startDateTime;
            set
            {
                _startDateTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDateTime
        {
            get => _endDateTime;
            set
            {
                _endDateTime = value;
                OnPropertyChanged();
            }
        }

        public PlanPriorityLevel PriorityLevel
        {
            get => _priorityLevel;
            set
            {
                _priorityLevel = value;
                OnPropertyChanged();
            }
        }

        public bool IsDisable
        {
            get => _isDisable;
            set
            {
                _isDisable = value;
                OnPropertyChanged();
            }
        }

        public PlanState State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected bool Equals(Plan other)
        {
            return string.Equals(_title, other._title) && string.Equals(_detail, other._detail) && _startDateTime.Equals(other._startDateTime) && _endDateTime.Equals(other._endDateTime) && _priorityLevel == other._priorityLevel && _state == other._state && _isDisable == other._isDisable;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_title != null ? _title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_detail != null ? _detail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _startDateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ _endDateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) _priorityLevel;
                hashCode = (hashCode * 397) ^ (int) _state;
                hashCode = (hashCode * 397) ^ _isDisable.GetHashCode();
                return hashCode;
            }
        }
    }
}