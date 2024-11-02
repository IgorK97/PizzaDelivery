using BLL.Models;
using Exceptions;
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
    public class SaveProfileChanges : CommandBase
    {
        private readonly AccountModel _user;
        private readonly ProfilePresentationVM _profilepresentationVM;
        public override void Execute(object parameter)
        {
            try
            {
                _user.SaveChanges();
                //_user.SaveChanges();
                //_user.MakeLogin(_authorizationVM.TextLogin, _authorizationVM.TextPassword);
                MessageBox.Show("Изменения сохранены!", "Success", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
            catch (IncorrectLoginOrPasswordException)
            {
                MessageBox.Show("Ошибка сохранения!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //public override bool CanExecute(object parameter)
        //{
        //    return !(string.IsNullOrEmpty(_authorizationVM.TextLogin) ||
        //        string.IsNullOrEmpty(_authorizationVM.TextPassword) ||
        //        _authorizationVM.TextLogin.Length <= 3) && base.CanExecute(parameter);
        //}
        public SaveProfileChanges(ViewModels.ProfilePresentationVM profilePresentationVM, AccountModel user)
        {
            _user = user;
            _profilepresentationVM = profilePresentationVM;

            _profilepresentationVM.PropertyChanged += OnViewModelPropertyChanged;
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
