using BLL.Models;
using PizzaDelivery.Commands;
using PizzaDelivery.State.Authenticators;
using PizzaDelivery.State.Navigators;
using PizzaDelivery.Stores;
using PizzaDelivery.Util;
using PizzaDelivery.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //private readonly NavigationStore _navigationStore;
        private readonly INavigator _navigator;
        private readonly IPizzaDeliveryViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;

        private ICommand updateCurrentViewModelCommand;
        public ICommand UpdateCurrentViewModelCommand
        {
            get
            {
                return updateCurrentViewModelCommand ??= new Commands.DelegateCommand(obj =>
                    {
                        if (obj is State.Navigators.ViewType)
                        {
                            State.Navigators.ViewType viewType = (State.Navigators.ViewType)obj;
                            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
                            
                        }
                });
            }
        }
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _navigator.CurrentViewModel;
            }
        } 

        //public MainViewModel(AccountModel _user)
        //{
        //    //CurrentViewModel = new AuthorizationVM(_user);
        //    //CurrentViewModel = new PizzaSelectionVM();
        //    CurrentViewModel = new ProfilePresentationVM(_user);
        //}

        public MainViewModel(INavigator navigator, IPizzaDeliveryViewModelFactory viewModelFactory,
            IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _authenticator.StateChanged += Authenticator_StateChanged;
            //UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(State.Navigators.ViewType.Login);
            _navigator.StateChanged += Navigator_StateChanged;
        }
        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }
}
