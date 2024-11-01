using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLL.Models;
using PizzaDelivery.Commands;
using PizzaDelivery.Util;

namespace PizzaDelivery.ViewModels
{
    public class ProfilePresentationVM : ViewModelBase
    {
        AccountModel User;
        
        private string _firstname;

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        private string _lastname;
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
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
        private string _password;
        public string Password
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
        public string? Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
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
        private string? _reppassword;
        public string? RepPassword
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

        private string _saveprofilechangesCommand;

        public ICommand SaveProfileChangesCommand
        {
            get;


        }

        public ProfilePresentationVM(AccountModel _user)
        {
            SaveProfileChangesCommand = new SaveProfileChanges(this, _user);
            User = _user;
            Firstname = User.FirstName;
            Lastname = User.LastName;
            Surname = User.Surname;
            Phone = User.Phone;
            Address = User.AddressDel;
            Email = User.Email;
            Login = User.Login;
            Password = User.Password;
        }
    }
}
