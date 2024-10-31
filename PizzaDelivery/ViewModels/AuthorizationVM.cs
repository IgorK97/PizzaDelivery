using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDelivery.Constants;
using PizzaDelivery.Commands;
using BLL.Models;

namespace PizzaDelivery.ViewModels
{
    public class AuthorizationVM : ViewModelBase
    {
        //private readonly INavigationManager _navigationManager;

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
        public AuthorizationVM(AccountModel _user)
        {
            ShowPizzaSelectionCommand = new LoginCommand(this, _user);
        }

        private ICommand _showPizzaSelectionCommand;
        public ICommand ShowPizzaSelectionCommand
        {
            get;
            
                //    return _showPizzaSelectionCommand ??
                //        (_showPizzaSelectionCommand = new PizzaDelivery.Util.DelegateCommand(ShowPizzaSelection));
                //}
            
        }
        //private void ShowPizzaSelection(object arg)
        //{
        //    //_navigationManager.Navigate(NavigationKeys.PizzaSelection);
        //}

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

        private ICommand _showRegCommand;
        public ICommand ShowRegCommand
        {
            get
            {
                return _showRegCommand ??
                    (_showRegCommand = new PizzaDelivery.Util.DelegateCommand(ShowReg));
            }
        }
        private void ShowReg(object arg)
        {
            //_navigationManager.Navigate(NavigationKeys.RegAccountInPD);
        }
    }
}
