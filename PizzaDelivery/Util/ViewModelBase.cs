using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PizzaDelivery.Util
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName = null)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null) 
        //        handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected virtual bool SetProperty<T>(ref T storage, T value, string propertyName = "")
        //{
        //    if (EqualityComparer<T>.Default.Equals(storage,value)) return false;
        //    storage = value;
        //    OnPropertyChanged(propertyName);
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
    }
}
