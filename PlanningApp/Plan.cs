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

    public class Plan : ViewModelBase
    {
        private string _detail;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private PlanPriorityLevel _priorityLevel;
        private bool _isDone;

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

        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                OnPropertyChanged();
            }
        }
    }
}