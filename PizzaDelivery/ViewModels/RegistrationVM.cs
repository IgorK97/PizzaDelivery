using BLL.Models;
using PizzaDelivery.Commands;
using PizzaDelivery.Stores;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class RegistrationVM : ViewModelBase
    {
        AccountModel User;
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
        public string? AddressDel
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                User.AddressDel = value;
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

        public ICommand ShowPizzaSelectionCommand
        {
            get;
            
        }
        public ICommand ShowEnterViewCommand
        {
            get;
        }
        public RegistrationVM(/*NavigationStore navigationstore, AccountModel _user*/)
        {
            //User = _user;
            //ShowPizzaSelectionCommand = new AddNewUserAndEnterCommand(navigationstore, this, _user);

            //ShowEnterViewCommand = new AddNewUserAndEnterCommand(navigationstore, this, _user);
            //ShowRegCommand = new RegistrationCommand(navigationstore, _user);
        }
    }
}
