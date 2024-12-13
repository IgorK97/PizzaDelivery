using DTO;
using Interfaces.Services.AuthenticationServices;
using Interfaces.Services.Authenticators;
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
    public class ProfilePresentationCourierVM : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        //AccountModel User;
        //UserVM UserB;
        private string _firstname;
        //public static event PasswordBoxesIsNull OnPasswordBoxesIsNull;

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
        private SecureString? _password;
        public SecureString? Password
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

        private ICommand saveProfileChangesCommand;

        public ICommand SaveProfileChangesCommand
        {
            get
            {
                return saveProfileChangesCommand ??= new Commands.DelegateCommand(obj =>
                {
                    NetworkCredential networkCredential = new NetworkCredential(Login, Password);
                    NetworkCredential networkCredentialsecond = new NetworkCredential(Login, RepPassword);

                    CouriersDto testUser = new CouriersDto
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Surname = Surname,
                        Login = Login,
                        Password = networkCredential.Password,
                        Phone = Phone,
                        Email = Email
                    };
                    RegistrationResult result = _authenticator.UpdateAccount(testUser, networkCredentialsecond.Password);
                    if (result == RegistrationResult.Success)
                    {
                        //_password.Clear();
                        //_reppassword.Clear();
                        //OnPasswordBoxesIsNull?.Invoke(this, new EventArgs());
                        //State.Navigators.ViewType viewType = State.Navigators.ViewType.Login;
                        //OnViewModelChangedDelegate(viewType);
                    }
                },
                    abj =>
                    {
                        return !string.IsNullOrEmpty(Login) &&
                Password != null && RepPassword != null &&
                Login.Length > 3 && !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Phone);
                    });
            }


        }

        public ProfilePresentationCourierVM(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            UserDTO userDTO = _authenticator.CurrentUser;
            FirstName = userDTO.FirstName;
            LastName = userDTO.LastName;
            Surname = userDTO.Surname;
            Login = userDTO.Login;
            Phone = ((CouriersDto)userDTO).Phone;
            Email = ((CouriersDto)userDTO).Email;
        }
    }
}
