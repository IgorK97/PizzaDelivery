using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PizzaDelivery.Util
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    public abstract class ViewModelBase : ObservableObject
    {
        //public event PropertyChangedEventHandler PropertyChanged;

      

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }
}
