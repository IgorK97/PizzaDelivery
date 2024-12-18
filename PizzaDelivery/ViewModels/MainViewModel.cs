﻿using BLL.Models;
using PizzaDelivery.Commands;
using Interfaces.Services.Authenticators;
using PizzaDelivery.State.Navigators;
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
        private readonly OrderBook _orderBook;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public bool IsClient => _authenticator.Account.IsClient;
        public bool IsCourier => _authenticator.Account.IsCourier;
        public bool IsManager => _authenticator.Account.IsManager;

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
            IAuthenticator authenticator, OrderBook orderBook)
        {
            ViewModelBase.ViewModelChanged += ViewModel_StateChanged;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _authenticator.StateChanged += Authenticator_StateChanged;
            //UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(State.Navigators.ViewType.Login);
            _navigator.StateChanged += Navigator_StateChanged;
            _orderBook = orderBook;
        }
        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsClient));
            OnPropertyChanged(nameof(IsCourier));
            OnPropertyChanged(nameof(IsManager));
            if(_authenticator.Account.IsClient)
            _orderBook.Load();
        }

        public void ViewModel_StateChanged(State.Navigators.ViewType viewType)
        {
            
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
        }
    }
}
