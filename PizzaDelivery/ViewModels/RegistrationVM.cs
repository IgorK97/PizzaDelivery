using BLL.Models;
using DTO;
using Interfaces.Services.AuthenticationServices;
using PizzaDelivery.Commands;
using PizzaDelivery.State.Authenticators;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class RegistrationVM : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private string _firstname;

        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string? _surname;
        public string? Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        private SecureString _password;
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string? _email;
        public string? Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string? _address;
        public string? AddressDel
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(AddressDel));
            }
        }
        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private SecureString? _reppassword;
        public SecureString? RepPassword
        {
            get
            {
                return _reppassword;
            }
            set
            {
                _reppassword = value;
                OnPropertyChanged(nameof(RepPassword));
            }
        }
        private ICommand viewLoginCommand;
        public ICommand ViewLoginCommand
        {
            get
            {
                return viewLoginCommand ??= new Commands.DelegateCommand(obj =>
                {

                    State.Navigators.ViewType viewType = State.Navigators.ViewType.Login;
                //    if(!string.IsNullOrEmpty(Login) &&
                //Password != null &&
                //Login.Length <= 3 && !string.IsNullOrEmpty(FirstName) &&
                //!string.IsNullOrEmpty(LastName) &&
                //!string.IsNullOrEmpty(Phone))
                    OnViewModelChangedDelegate(viewType);

                });

            }
        }

        private ICommand registerCommand;
        public ICommand RegisterCommand
        {
            get
            {
                return registerCommand ??= new Commands.DelegateCommand(obj =>
                {
                    NetworkCredential networkCredential = new NetworkCredential(Login, Password);
                    NetworkCredential networkCredentialsecond = new NetworkCredential(Login, RepPassword);

                    ClientDTO testUser = new ClientDTO
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Surname = Surname,
                        Login = Login,
                        Password = networkCredential.Password,
                        Phone = Phone,
                        Email = Email,
                        AddressDel = AddressDel
                    };
                    RegistrationResult result = _authenticator.Register(testUser,/* TextPassword.ToString()*/
                        networkCredentialsecond.Password);
                    if (result==RegistrationResult.Success)
                    {
                        State.Navigators.ViewType viewType = State.Navigators.ViewType.Login;
                        OnViewModelChangedDelegate(viewType);
                    }
                },
                    abj =>
                    {
                        return !string.IsNullOrEmpty(Login) &&
                Password != null &&
                Login.Length > 3 && !string.IsNullOrEmpty(FirstName)&&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Phone);
                    });
            }
        }
        public RegistrationVM(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }
    }
}
