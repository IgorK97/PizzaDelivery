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
using PizzaDelivery.State.Authenticators;
using System.Security;
using System.Net;

namespace PizzaDelivery.ViewModels
{
    public class AuthorizationVM : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
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

        private SecureString _textPassword;
        public SecureString TextPassword
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
        public AuthorizationVM(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        private ICommand /*PizzaDelivery.Commands.DelegateCommand*/ loginCommand;
       
        public ICommand /*PizzaDelivery.Commands.DelegateCommand*/ LoginCommand
        {
            get
            {
                return loginCommand ??= new Commands.DelegateCommand(obj =>
                    {
                        NetworkCredential networkCredential = new NetworkCredential(TextLogin, TextPassword);
                        //string str = TextPassword.ToString();
                        bool success = _authenticator.Login(networkCredential.UserName,/* TextPassword.ToString()*/
                            networkCredential.Password);
                    }, 
                    abj =>
                    {
                        return true;
                    });
            }
            
        }
        //public void Login()
        //{

        //}

        //public bool canExecuteLogin()
        //{
        //    return true;
        //}

        //private bool CanExecuteLogin(object obj)
        //{
        //    bool validData;
        //    if (string.IsNullOrWhiteSpace(TextLogin) || TextLogin.Length <= 3 || 
        //        TextPassword == null)
        //        validData = false;
        //    else 
        //        validData = true;
        //    return validData;
        //}

        //private ICommand _showRegCommand;
        public ICommand ShowRegCommand
        {
            get;
        }
        
    }
}
