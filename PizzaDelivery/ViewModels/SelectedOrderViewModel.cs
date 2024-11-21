using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class SelectedOrderViewModel : ViewModelBase
    {
        private string _cost;
        public string Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
        private string _count;
        public string Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }
}
