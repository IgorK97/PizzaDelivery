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
    public class OrderHistoryViewModel :ViewModelBase
    {
        private ObservableCollection<OrderViewModel> _ordercollection;
        public IEnumerable<OrderViewModel> OrderCollection
        {
            get
            {
                if (_ordercollection != null)
                    return _ordercollection;
                else
                    Load();
                return _ordercollection;
            }
        }
        private OrderViewModel _selectedOrder;
        public OrderViewModel SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public void OnOrderViewModelIsDeleted()
        {
            Load();
            OnPropertyChanged(nameof(OrderCollection));
        }
        private SelectedOrderViewModel watchingOrder;
        public SelectedOrderViewModel WatchingOrder
        {
            get
            {
                return watchingOrder;
            }
            set
            {
                watchingOrder = value;
                OnPropertyChanged(nameof(WatchingOrder));

            }
        }
        private SelectedOrderViewModel selectedOrderVM;
        public SelectedOrderViewModel SelectedOrderVM
        {
            get
            {
                return selectedOrderVM;
            }
            set
            {
                selectedOrderVM = value;
                OnPropertyChanged(nameof(SelectedOrderVM));

            }
        }
        private bool _isOrderSelected;
        public bool IsOrderSelected
        {
            get
            {
                return _isOrderSelected;
            }
            set
            {
                _isOrderSelected = value;
                OnPropertyChanged(nameof(IsOrderSelected));
            }
        }
        private readonly OrderBook _orderBook;
        public OrderHistoryViewModel(OrderBook orderBook)
        {
            _orderBook = orderBook;
            IsOrderSelected = false;
            OrderViewModel.OnOrderIsDeleted += OnOrderViewModelIsDeleted;
            OrderViewModel.OnOrderIsAbout += OnOrderViewModelIsAbout;
            SelectedOrderViewModel.OnExitCommand += OnExitSelected;
        }
        public void OnOrderViewModelIsAbout(OrderViewModel _orderViewModel)
        {
            //IsOrderSelected = true;
            //SelectedOrder = _orderViewModel;
            //bool p;
            //if (DelStatus == DeliveryStatus.AtTheCourier)
            //    p = true;
            //else
            //    p = false;
            //SelectedOrderCommentVM = new CommentViewModel(_orderViewModel.OrderModel, p);
            WatchingOrder = new SelectedOrderViewModel(_orderViewModel.OrderModel);

            IsOrderSelected = true;

            //_deliverySystemModel.TakeOrder(Id);
            //OnOrderViewModelIsChanged();
        }
        public void OnExitSelected()
        {
            IsOrderSelected = false;

        }
        public void Load()
        {
            _ordercollection = new ObservableCollection<OrderViewModel>();
            _orderBook.Load();
            IEnumerable<OrderModel> _lines = _orderBook.Orders;

            foreach (OrderModel olm in _lines)
            {
                if (olm.delstatusId != 1)
                {
                    OrderViewModel olvm = new OrderViewModel(olm);
                    _ordercollection.Add(olvm);
                }
            }
        }
        //private ICommand selectOrderCommand;
        //public ICommand SelectOrderCommand
        //{
        //    get
        //    {
        //        return selectOrderCommand;
        //    }
        //}
    }
}
