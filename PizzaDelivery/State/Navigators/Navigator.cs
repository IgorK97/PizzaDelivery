﻿using PizzaDelivery.Commands;
using PizzaDelivery.Util;
using PizzaDelivery.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;


        //public event PropertyChangedEventHandler? PropertyChanged;
        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        //}
        //public Navigator(IPizzaDeliveryViewModelAbstractFactory pizzaDeliveryViewModelAbstractFactory)
        //{
        //    UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, pizzaDeliveryViewModelAbstractFactory);
        //}
    }
}
