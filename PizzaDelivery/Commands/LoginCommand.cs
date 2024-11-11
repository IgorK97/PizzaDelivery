using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDelivery.ViewModels;
using System.Linq.Expressions;
using System.Windows;
using System.ComponentModel;
using PizzaDelivery.Stores;

namespace PizzaDelivery.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly AccountModel _user;
        private readonly AuthorizationVM _authorizationVM;
        private readonly NavigationStore _navigationStore;
        public override void Execute(object parameter)
        {
            //try
            //{
            //    _user.MakeLogin(_authorizationVM.TextLogin, _authorizationVM.TextPassword);
            //    MessageBox.Show("Добро пожаловать!", "Success", MessageBoxButton.OK,
            //       MessageBoxImage.Information);
            //    _navigationStore.CurrentViewModel=new ProfilePresentationVM(/*_user*/);
            //}
            //catch (IncorrectLoginOrPasswordException)
            //{
            //    MessageBox.Show("Неправильный логин или пароль", "Error", MessageBoxButton.OK, 
            //        MessageBoxImage.Error);
            //}
        }

        public override bool CanExecute(object parameter)
        {
            return true;
            //return !(string.IsNullOrEmpty(_authorizationVM.TextLogin)||
            //    string.IsNullOrEmpty(_authorizationVM.TextPassword)||
            //    _authorizationVM.TextLogin.Length<=3) && base.CanExecute(parameter);
        }
        public LoginCommand(NavigationStore navigationstore, ViewModels.AuthorizationVM authorizationVM, AccountModel user)
        {
            _user = user;
            _authorizationVM = authorizationVM;
            _navigationStore = navigationstore;
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
