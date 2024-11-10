using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
        PhoneAlreadyExists
    }
    public interface IAuthenticationService
    {
        RegistrationResult Register(ClientDTO _user, string confirmPassword);
        UserDTO Login(string login, string password);
    }
}

