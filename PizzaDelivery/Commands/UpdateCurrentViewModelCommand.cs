using PizzaDelivery.State.Navigators;
using PizzaDelivery.ViewModels;
using PizzaDelivery.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IPizzaDeliveryViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IPizzaDeliveryViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is State.Navigators.ViewType)
            {
                State.Navigators.ViewType viewType = (State.Navigators.ViewType)parameter;
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
                //switch (viewType)
                //{
                //    case Util.Navigators.ViewType.Login:
                //        //_navigator.CurrentViewModel = new AuthorizationVM();
                //        break;
                //    case Util.Navigators.ViewType.Registration:
                //        //_navigator.CurrentViewModel = new RegistrationVM();
                //        break;
                //    case Util.Navigators.ViewType.Profile:
                //        //_navigator.CurrentViewModel = new ProfilePresentationVM();
                //        break;
                //    default:
                //        break;
                //}
            }
        }
    }
}
