using DTO;
using Interfaces.Services.AuthenticationServices;
using PizzaDelivery.Interfaces.Services;
using PizzaDelivery.State.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        public int Id
        {
            get
            {
                return CurrentUser.Id;
            }
            //set
            //{
            //    CurrentUser.Id = value;
            //}
        }
        private readonly IAuthenticationService _authenticationService;
        private IAccountStore _accountStore;
        public IAccountStore Account
        {
            get
            {
                return _accountStore;
            }
            set
            {
                _accountStore = value;
            }
        }
        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore= accountStore;
        }
        
        public UserDTO CurrentUser { get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                _accountStore.Id = value.Id;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;

        public bool IsLoggedIn => CurrentUser != null;

        public bool Login(string login, string password)
        {
            bool success = true;
            try
            {
                CurrentUser = _authenticationService.Login(login, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public RegistrationResult Register(ClientDTO user, string confirmpassword)
        {
            return _authenticationService.Register(user, confirmpassword);
        }

        public RegistrationResult UpdateAccount(UserDTO user, string confirmpassword)
        {
            _accountStore.CurrentAccount = user;
            user.Id = _accountStore.Id;

            //user.Password = _passwordHasher.HashPassword(user.Password);
            return _authenticationService.UpdateAccount(user, confirmpassword);
        }
    }
}
