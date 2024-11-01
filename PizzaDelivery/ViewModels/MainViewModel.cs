using BLL.Models;
using PizzaDelivery.Stores;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel { get => _navigationStore.CurrentViewModel; }

        //public MainViewModel(AccountModel _user)
        //{
        //    //CurrentViewModel = new AuthorizationVM(_user);
        //    //CurrentViewModel = new PizzaSelectionVM();
        //    CurrentViewModel = new ProfilePresentationVM(_user);
        //}

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
