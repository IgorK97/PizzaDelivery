using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentVoewModel;
        public ViewModelBase CurrentViewModel { 
            get => _currentVoewModel;
            set
            {
                _currentVoewModel = value;
                OnCurrentViewModelChanged();
            } 
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public event Action CurrentViewModelChanged;
    }
}
