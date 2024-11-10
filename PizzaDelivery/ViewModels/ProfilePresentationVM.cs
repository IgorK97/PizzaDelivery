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
        //UserVM UserB;
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
                User.FirstName = value;
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
                User.LastName = value;
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
                User.Surname = value;
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
                User.Login = value;
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
                User.Password = value;
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
                User.Email = value;
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
                User.AddressDel= value;
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
                User.Phone = value;
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

        private ICommand _saveprofilechangesCommand;

        public ICommand SaveProfileChangesCommand
        {
            get
            {
                return _saveprofilechangesCommand;
            }


        }

        public ProfilePresentationVM(/*AccountModel _user*/)
        {
            //_saveprofilechangesCommand = new SaveProfileChanges(this, _user);
            //User = _user;
            ////UserB = new UserVM();
            //FirstName = User.FirstName;
            //LastName = User.LastName;
            //Surname = User.Surname;
            //Phone = User.Phone;
            //Address = User.AddressDel;
            //Email = User.Email;
            //Login = User.Login;
            //Password = User.Password;
        }
    }
}
