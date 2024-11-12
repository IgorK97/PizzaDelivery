using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PizzaDelivery.Util
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    public delegate void ViewModelChangedDelegate(State.Navigators.ViewType viewModelType);
    public abstract class ViewModelBase : ObservableObject
    {
        public static event ViewModelChangedDelegate ViewModelChanged;

        public void OnViewModelChangedDelegate(State.Navigators.ViewType viewType)
        {
            ViewModelChanged?.Invoke(viewType);
        }

    }
}
