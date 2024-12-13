using DTO;
using Interfaces.Services.AuthenticationServices;
using PizzaDelivery.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services.Authenticators
{
    public interface IAuthenticator
    {
        int Id { get; }
        UserDTO CurrentUser { get; }
        bool IsLoggedIn { get; }
        IAccountStore Account { get; set; }
        RegistrationResult UpdateAccount(UserDTO user, string confirmstring);
        RegistrationResult Register(ClientDTO user, string confirmpassword);
        bool Login(string login, string password);
        void Logout();
        event Action StateChanged;
    }
}
