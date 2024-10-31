using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDelivery.ViewModels;
using System.Linq.Expressions;
using Exceptions;
using System.Windows;
using System.ComponentModel;

namespace PizzaDelivery.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly AccountModel _user;
        private readonly AuthorizationVM _authorizationVM;
        public override void Execute(object parameter)
        {
            try
            {
                _user.MakeLogin(_authorizationVM.TextLogin, _authorizationVM.TextPassword);
                MessageBox.Show("Добро пожаловать!", "Success", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
            catch (IncorrectLoginOrPasswordException)
            {
                MessageBox.Show("Неправильный логин или пароль", "Error", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !(string.IsNullOrEmpty(_authorizationVM.TextLogin)||
                string.IsNullOrEmpty(_authorizationVM.TextPassword)||
                _authorizationVM.TextLogin.Length<=3) && base.CanExecute(parameter);
        }
        public LoginCommand(ViewModels.AuthorizationVM authorizationVM, AccountModel user)
        {
            _user = user;
            _authorizationVM = authorizationVM;

            _authorizationVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AuthorizationVM.TextLogin)||
                e.PropertyName==nameof(AuthorizationVM.TextPassword)) {
                OnCanExecuteChanged();
            }
        }
    }
}
