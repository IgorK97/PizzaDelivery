using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDelivery.Constants;

namespace PizzaDelivery.ViewModels
{
    public class AuthorizationVM : ViewModelBase
    {
        private readonly INavigationManager _navigationManager;

        public AuthorizationVM(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        private ICommand _showPizzaSelectionCommand;
        public ICommand ShowPizzaSelectionCommand
        {
            get {
                return _showPizzaSelectionCommand ??
                    (_showPizzaSelectionCommand = new PizzaDelivery.Util.DelegateCommand(ShowPizzaSelection));
            }
        }
        private void ShowPizzaSelection(object arg)
        {
            _navigationManager.Navigate(NavigationKeys.PizzaSelection);
        }
    }
}
