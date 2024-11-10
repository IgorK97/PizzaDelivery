using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels.Factories
{
    public interface IPizzaDeliveryViewModelFactory
    {
        ViewModelBase CreateViewModel(Util.Navigators.ViewType viewType);
    }
}
