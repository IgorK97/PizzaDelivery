using DTO;
using Interfaces.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        private UserDTO _currentUser;
        public UserDTO CurrentUser { get
            {
                return _currentUser;
            }
            private set
            {
                _currentUser = value;
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
    }
}
