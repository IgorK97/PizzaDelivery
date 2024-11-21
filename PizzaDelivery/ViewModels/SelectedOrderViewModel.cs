using BLL.Models;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class SelectedOrderViewModel : ViewModelBase
    {
        OrderModel _orderModel;
        public static event ExitDelegate OnExitCommand;
        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand ??= new Commands.DelegateCommand(obj =>
                {
                    OnExitCommand?.Invoke();
                });
            }
        }
        private ObservableCollection<OrderLineViewModel> _linescollection;
        public IEnumerable<OrderLineViewModel> LinesCollection
        {
            get
            {
                if (_linescollection != null)
                    return _linescollection;
                else
                    Load();
                return _linescollection;
            }
        }
        public void Load()
        {
            _linescollection = new ObservableCollection<OrderLineViewModel>();
            IEnumerable<OrderLineModel> _lines = _orderModel.GetLines();

            foreach (OrderLineModel olm in _lines)
            {
                OrderLineViewModel olvm = new OrderLineViewModel(olm);
                _linescollection.Add(olvm);
            }
        }
        private OrderLineViewModel _selectedLine;
        public OrderLineViewModel SelectedLine
        {
            get
            {
                return _selectedLine;
            }
            set
            {
                _selectedLine = value;
                OnPropertyChanged(nameof(SelectedLine));
            }
        }
        
        public SelectedOrderViewModel(OrderModel om)
        {
            _orderModel = om;

        }
    }
}
