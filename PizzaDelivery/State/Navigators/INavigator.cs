using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDelivery.Util;

namespace PizzaDelivery.State.Navigators
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
    }
}
