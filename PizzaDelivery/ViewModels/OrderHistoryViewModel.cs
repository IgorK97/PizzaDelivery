using BLL.Models;
using DomainModel;
using DTO;
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
        private bool isOrderCommented;
        public bool IsOrderCommented
        {
            get
            {
                return isOrderCommented;
            }
            set
            {
                isOrderCommented = value;
                OnPropertyChanged(nameof(IsOrderCommented));
            }
        }
        private CommentViewModel selectedOrderCommentVM;
        public CommentViewModel SelectedOrderCommentVM
        {
            get
            {
                return selectedOrderCommentVM;
            }
            set
            {
                selectedOrderCommentVM = value;
                OnPropertyChanged(nameof(SelectedOrderCommentVM));

            }
        }
        public void OnOrderViewModelIsDelivered(OrderViewModel _orderViewModel)
        {
            //IsOrderSelected = true;
            //SelectedOrder = _orderViewModel;
            bool p = false;
            SelectedOrderCommentVM = new CommentViewModel(_orderViewModel.OrderModel, p);
            IsOrderCommented = true;

            //_deliverySystemModel.TakeOrder(Id);
            //OnOrderViewModelIsChanged();
        }
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
        private bool _notification;
        public bool Notification
        {
            get
            {
                return _notification;
            }
            set
            {
                _notification = value;
                OnPropertyChanged(nameof(Notification));
            }
        }
        public void OnOrderViewModelIsDeleted(OrderViewModel ovm)
        {
            Notification = true;
            SelectedOrder = ovm;
            //Load();
            //OnPropertyChanged(nameof(OrderCollection));
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                return close ??= new Commands.DelegateCommand(obj =>
                { Notification = false; });
            }
        }
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                return cancel??= new Commands.DelegateCommand(obj =>
                {
                    SelectedOrder.OrderModel.CancelYourself();
                    Notification = false;
                    Load();
                    OnPropertyChanged(nameof(OrderCollection));
                });
            }
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
            CommentViewModel.OnExitDelegate += OnExitEvent;
            OrderViewModel.OnOrderIsDelivered += OnOrderViewModelIsDelivered;

        }
        public void OnExitEvent()
        {
            //IsOrderSelected = false;
            IsOrderCommented = false;
            //if (_selectedOrder != null) //Когда будут диспоуз вьюмодел делать, убрать
            //    _selectedOrder.UpdateProperties();
            //OnPropertyChanged(nameof(SelectedLine));
            //OnPropertyChanged(nameof(LinesCollection));
            //OnPropertyChanged(nameof(Price));
            //OnPropertyChanged(nameof(Weight));
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
