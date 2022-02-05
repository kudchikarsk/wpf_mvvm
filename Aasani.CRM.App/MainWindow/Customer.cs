﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aasani.CRM.App
{
    public class Customer : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string phone;
        private bool isDeveloper;

        public string FirstName { get => firstName; set => OnPropertyChange(ref firstName, value); }
        public string LastName { get => lastName; set => OnPropertyChange(ref lastName, value); }
        public string Phone { get => phone; set => OnPropertyChange(ref phone, value); }
        public bool IsDeveloper { get => isDeveloper; set => OnPropertyChange(ref isDeveloper, value); }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChange<T>(ref T prop, T value, [CallerMemberName] string callingMember = null)
        {
            prop = value;
            PropertyChanged(this, new PropertyChangedEventArgs(callingMember));
        }
    }
}