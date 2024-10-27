using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class PizzaSelectionVM : ViewModelBase, PizzaDelivery.Util.INavigationAware
    {
        private readonly INavigationManager _navigationManager;

        public PizzaSelectionVM(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void OnNavigatingFrom()
        {

        }

        public void OnNavigatingTo(object arg)
        {

        }
    }
}
