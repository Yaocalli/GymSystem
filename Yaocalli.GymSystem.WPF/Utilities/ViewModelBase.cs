using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Yaocalli.GymSystem.WPF.Utilities
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if(Equals(member,val))return;
            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyCanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged =  delegate{ };
    }
}
