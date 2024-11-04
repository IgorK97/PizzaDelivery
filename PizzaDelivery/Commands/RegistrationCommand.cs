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
    public class RegistrationCommand : CommandBase
    {
        private readonly AccountModel _user;
        //private readonly AuthorizationVM _authorizationVM;
        private readonly NavigationStore _navigationStore;
        public override void Execute(object parameter)
        {
            
                //_user.MakeLogin(_authorizationVM.TextLogin, _authorizationVM.TextPassword);
                //MessageBox.Show("Добро пожаловать!", "Success", MessageBoxButton.OK,
                //   MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new RegistrationVM(_navigationStore, _user);
            
        }

        
        public RegistrationCommand(NavigationStore navigationstore, /*ViewModels.AuthorizationVM authorizationVM, */AccountModel user)
        {
            _user = user;
            //_authorizationVM = authorizationVM;
            _navigationStore = navigationstore;
            //_authorizationVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        
    }
}

