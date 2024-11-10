using BLL.Models;
using PizzaDelivery.Commands;
using PizzaDelivery.Stores;
using PizzaDelivery.Util;
using PizzaDelivery.Util.Navigators;
using PizzaDelivery.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //public INavigator Navigator { get; set; }

        public ICommand UpdateCurrentViewModelCommand { get; }

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

        public MainViewModel(INavigator navigator, IPizzaDeliveryViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(Util.Navigators.ViewType.Login);
            _navigator.StateChanged += Navigator_StateChanged;
        }
        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        //private void OnCurrentViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(CurrentViewModel));
        //}
    }
}
