using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aasani.CRM.App
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void SetProperty<T>(ref T prop, T value, [CallerMemberName] string member = "")
        {
            prop = value;
            PropertyChanged(this, new PropertyChangedEventArgs(member));
        }
    }
}
