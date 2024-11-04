using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDelivery.Commands;
using BLL.Models;
using PizzaDelivery.Stores;

namespace PizzaDelivery.ViewModels
{
    public class AuthorizationVM : ViewModelBase
    {

        private string _textLogin;

        public string TextLogin
        {
            get
            {
                return _textLogin;
            }

            set
            {
                _textLogin = value;
                OnPropertyChanged("TextLogin");
            }
        }

        private string _textPassword;
        public string TextPassword
        {
            get
            {
                return _textPassword;
            }

            set
            {
                _textPassword = value;
                OnPropertyChanged("TextPassword");
            }
        }
        public AuthorizationVM(NavigationStore navigationstore, AccountModel _user)
        {
            ShowPizzaSelectionCommand = new LoginCommand(navigationstore, this, _user);
            ShowRegCommand = new RegistrationCommand(navigationstore, _user);
        }

        //private ICommand _showPizzaSelectionCommand;
        public ICommand ShowPizzaSelectionCommand
        {
            get;
            
                
            
        }
        

        private bool CanExecuteLogin(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(TextLogin) || TextLogin.Length <= 3 || 
                TextPassword == null)
                validData = false;
            else 
                validData = true;
            return validData;
        }

        //private ICommand _showRegCommand;
        public ICommand ShowRegCommand
        {
            get;
        }
        
    }
}
