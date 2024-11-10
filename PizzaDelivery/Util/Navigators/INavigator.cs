using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.Util.Navigators
{
    public enum ViewType
    {
        Profile,
        Basket,
        Shop,
        Registration,
        Login,
        OrderHistory
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
        //ICommand UpdateCurrentViewModelCommand { get; }
    }
}
