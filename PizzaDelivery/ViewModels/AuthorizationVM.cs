using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDelivery.Commands;
using BLL.Models;
using Interfaces.Services.Authenticators;
using System.Security;
using System.Net;
using PizzaDelivery.State.Navigators;
using PizzaDelivery.ViewModels.Factories;

namespace PizzaDelivery.ViewModels
{
    public class AuthorizationVM : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private string _textLogin;
        //private readonly INavigator _navigator;
        //private readonly IPizzaDeliveryViewModelFactory _pizzaDeliveryViewModelFactory;
        private bool _notification;
        public bool Notification
        {
            get
            {
                return _notification;
            }
            set
            {
                _notification = value;
                OnPropertyChanged(nameof(Notification));
            }
        }
        public string TextLogin
        {
            get
            {
                return _textLogin;
            }

            set
            {
                _textLogin = value;
                OnPropertyChanged("TextLogin");
            }
        }

        private SecureString _textPassword;
        public SecureString TextPassword
        {
            get
            {
                return _textPassword;
            }

            set
            {
                _textPassword = value;
                OnPropertyChanged("TextPassword");
            }
        }
        public AuthorizationVM(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            Notification = false;
            //_navigator = navigator;
            //_pizzaDeliveryViewModelFactory = _pizzaDeliveryViewModelFactory;
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                return close ??= new Commands.DelegateCommand(obj =>
                {
                    Notification = false;
                });
            }
        }

        private ICommand loginCommand;
       
        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ??= new Commands.DelegateCommand(obj =>
                    {
                        NetworkCredential networkCredential = new NetworkCredential(TextLogin, TextPassword);
                        //string str = TextPassword.ToString();
                        bool success = _authenticator.Login(networkCredential.UserName,/* TextPassword.ToString()*/
                            networkCredential.Password);
                        if (success)
                        {
                            State.Navigators.ViewType viewType;
                            if (_authenticator.Account.IsClient)
                                viewType = State.Navigators.ViewType.Shop;
                            else if (_authenticator.Account.IsCourier)
                                viewType = State.Navigators.ViewType.OrdersCourier;
                            else
                                viewType = State.Navigators.ViewType.OrdersManager;
                            //if (_authenticator.Account.IsClient)
                            //    viewType = State.Navigators.ViewType.Profile;
                            //else if (_authenticator.Account.IsCourier)
                            //    viewType = State.Navigators.ViewType.ProfileCourier;
                            //else
                            //    viewType = State.Navigators.ViewType.ProfileManager;
                            OnViewModelChangedDelegate(viewType);
                            //_navigator.CurrentViewModel = _pizzaDeliveryViewModelFactory.CreateViewModel(viewType);
                        }
                        else
                        {
                            Notification = true;
                        }
                    },
                    abj =>
                    {
                        return !string.IsNullOrEmpty(TextLogin) && TextPassword != null;
                    })
                {

                };
            }
            
        }
        private ICommand viewRegisterCommand;
        public ICommand ViewRegisterCommand
        {
            get
            {
                return viewRegisterCommand ??= new Commands.DelegateCommand(obj =>
                {
                    
                        State.Navigators.ViewType viewType = State.Navigators.ViewType.Registration;
                        //_navigator.CurrentViewModel = _pizzaDeliveryViewModelFactory.CreateViewModel(viewType);
                        OnViewModelChangedDelegate(viewType);
                    
                });
            }
        }
        
    }
}
