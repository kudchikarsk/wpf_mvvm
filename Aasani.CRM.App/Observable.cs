using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aasani.CRM.App
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChange<T>(ref T prop, T value, [CallerMemberName] string callingMember = null)
        {
            prop = value;
            PropertyChanged(this, new PropertyChangedEventArgs(callingMember));
        }

        public void OnPropertyChange([CallerMemberName] string callingMember = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(callingMember));
        }
    }
}