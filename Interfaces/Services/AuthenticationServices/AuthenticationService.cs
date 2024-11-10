using DomainModel;
using DomainModel.Exceptions;
using DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }
        //private readonly IPasswordHasher _passwordHasher;

        public UserDTO Login(string login, string password)
        {
            UserDTO storedUser = _accountService.GetByLogin(login);
            if (storedUser == null)
            {
                throw new UserNotFoundException(login);
            }
            //IPasswordHasher _passwordHasher = new PasswordHasher();
            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword
                (storedUser.Password, password);
            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(login, password);
            }
            return storedUser;
        }

        public RegistrationResult Register(ClientDTO _user, string confirmPassword)
        {
            //IPasswordHasher _passwordHasher = new PasswordHasher();

            RegistrationResult result = RegistrationResult.Success;

            if (_user.Password != confirmPassword)
                result = RegistrationResult.PasswordDoNotMatch;

            UserDTO loginAccount = _accountService.GetByLogin(_user.Login);

            if (loginAccount != null)
                result = RegistrationResult.UsernameAlreadyExists;

            UserDTO phoneAccount = _accountService.GetByPhone(_user.Phone);

            if (phoneAccount != null)
                result = RegistrationResult.PhoneAlreadyExists;

            if (result == RegistrationResult.Success)
            {
                string password = _passwordHasher.HashPassword(_user.Password);
                ClientDTO newUser = new ClientDTO
                {
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Surname = _user.Surname,
                    Login = _user.Login,
                    Password = password,
                    AddressDel = _user.AddressDel,
                    Phone = _user.Phone,
                    Email = _user.Email,
                    Id = _user.Id

                };
                _accountService.Create(newUser);
            }

            return result;
        }
    }
}
