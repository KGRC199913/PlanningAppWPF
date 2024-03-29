﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PlanningApp.Annotations;

namespace PlanningApp
{
    [Serializable]
    public class ViewModelBase : INotifyPropertyChanged
    {
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}