using BLL.Models;
using Exceptions;
using PizzaDelivery.Stores;
using PizzaDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaDelivery.Commands
{
    public class AddNewUserAndEnterCommand : CommandBase
    {
        private readonly AccountModel _user;
        private readonly RegistrationVM _regVM;
        private readonly NavigationStore _navigationStore;

        public override void Execute(object parameter)
        {
            try
            {
                _user.MakeReg();
                //_user.SaveChanges();
                //_user.MakeLogin(_authorizationVM.TextLogin, _authorizationVM.TextPassword);
                MessageBox.Show("Изменения сохранены!", "Success", MessageBoxButton.OK,
                   MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new ProfilePresentationVM(_user);

            }
            catch (IncorrectLoginOrPasswordException)
            {
                MessageBox.Show("Ошибка сохранения!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //public override bool CanExecute(object parameter)
        //{
        //    return !(string.IsNullOrEmpty(_regVM.Login) ||
        //        string.IsNullOrEmpty(_regVM.Password) ||
        //        _regVM.Login.Length <= 3 ||
        //        string.IsNullOrEmpty(_regVM.Firstname) ||
        //        string.IsNullOrEmpty(_regVM.Lastname) ||
        //        string.IsNullOrEmpty(_regVM.Phone)) &&
        //        (_regVM.Password == _regVM.RepPassword)
        //        && base.CanExecute(parameter);
        //}
        public AddNewUserAndEnterCommand(NavigationStore navigationstore, ViewModels.RegistrationVM profilePresentationVM, AccountModel user)
        {
            _user = user;
            _regVM = profilePresentationVM;
            _navigationStore=navigationstore;
            _regVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == nameof(ProfilePresentationVM.TextLogin) ||
            //    e.PropertyName == nameof(AuthorizationVM.TextPassword))
            //{
            OnCanExecuteChanged();
            //}
        }
    }
}
