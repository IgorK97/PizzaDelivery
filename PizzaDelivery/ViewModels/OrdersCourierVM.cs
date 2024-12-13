using BLL.Models;
using DomainModel;
using DTO;
using Interfaces.Services;
using Interfaces.Services.Authenticators;
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
    public class OrdersCourierVM : ViewModelBase
    {
        private ObservableCollection<OrderViewModel> _orderscollection;
        public IEnumerable<OrderViewModel> OrdersCollection
        {
            get
            {
                if (_orderscollection != null)
                    return _orderscollection;
                else
                    Load();
                return _orderscollection;
            }
        }
        public void Load()
        {
            _orderscollection = new ObservableCollection<OrderViewModel>();
            _deliverySystemModel.Load();
            IEnumerable<OrderModel> _orders = _deliverySystemModel.GetNecesseryOrderList(DelStatus);

            foreach (OrderModel olm in _orders)
            {
                OrderViewModel olvm = new OrderViewModel(olm);
                _orderscollection.Add(olvm);
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
       

        //public void OnOrderLineViewModelIsChanged()
        //{
        //    OnPropertyChanged(nameof(Price));
        //    OnPropertyChanged(nameof(Weight));
        //}

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
        public void OnExitEvent()
        {
            IsOrderSelected = false;
            IsOrderCommented = false;
            Load();
            OnPropertyChanged(nameof(OrdersCollection));
            //if (_selectedOrder != null) //Когда будут диспоуз вьюмодел делать, убрать
            //    _selectedOrder.UpdateProperties();
            //OnPropertyChanged(nameof(SelectedLine));
            //OnPropertyChanged(nameof(LinesCollection));
            //OnPropertyChanged(nameof(Price));
            //OnPropertyChanged(nameof(Weight));
        }

        public bool IsBeingFormed
        {
            get
            {
                return DelStatus == DeliveryStatus.IsBeingFormed;
            }
        }
        public bool IsCooking
        {
            get
            {
                return DelStatus == DeliveryStatus.IsCooking;
            }
        }
        public bool HandedOver
        {
            get
            {
                return DelStatus == DeliveryStatus.HandedOver;
            }
        }
        public bool AtTheCourier
        {
            get
            {
                return DelStatus == DeliveryStatus.AtTheCourier;
            }
        }
        public bool Delivered
        {
            get
            {
                return DelStatus == DeliveryStatus.Delivered;
            }
        }
        public bool NotDelivered
        {
            get
            {
                return DelStatus == DeliveryStatus.NotDelivered;
            }
        }
        public bool Canceled
        {
            get
            {
                return DelStatus == DeliveryStatus.Canceled;
            }
        }
        private DeliveryStatus _delStatus;
        public DeliveryStatus DelStatus
        {
            get
            {
                return _delStatus;
            }
            set
            {
                _delStatus = value;
                StatusIsChanged();
            }
        }

        private void StatusIsChanged()
        {
            OnPropertyChanged(nameof(IsCooking));
            OnPropertyChanged(nameof(IsBeingFormed));
            OnPropertyChanged(nameof(Delivered));
            OnPropertyChanged(nameof(NotDelivered));
            OnPropertyChanged(nameof(Canceled));
            OnPropertyChanged(nameof(AtTheCourier));
            OnPropertyChanged(nameof(HandedOver));
        }

        private ICommand selectStatus;
        public ICommand SelectStatus
        {
            get
            {
                return selectStatus ??= new Commands.DelegateCommand(obj =>
                {
                    DelStatus = (DeliveryStatus)obj;
                    Load();
                    OnPropertyChanged(nameof(OrdersCollection));
                });
            }
        }
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


        //private readonly AssortmentModel _assortmentModel;
        private readonly DeliverySystemModel _deliverySystemModel;
        private readonly IAuthenticator _authenticator;
        private readonly IPriceBook _priceBook;
        //private readonly OrderBook _orderBook;
        //private OrderModel _basket;
        public void OnOrderViewModelIsChanged()
        {
            Load();
            OnPropertyChanged(nameof(OrdersCollection));
        }
        public void OnOrderViewModelIsTaked(int Id)
        {
            _deliverySystemModel.TakeOrder(Id);
            OnOrderViewModelIsChanged();
        }
        public void OnOrderViewModelIsDelivered(OrderViewModel _orderViewModel)
        {
            //IsOrderSelected = true;
            //SelectedOrder = _orderViewModel;
            bool p;
            if (DelStatus == DeliveryStatus.AtTheCourier)
                p = true;
            else
                p = false;
            SelectedOrderCommentVM = new CommentViewModel(_orderViewModel.OrderModel, p);
            IsOrderCommented = true;

            //_deliverySystemModel.TakeOrder(Id);
            //OnOrderViewModelIsChanged();
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
            SelectedOrderVM = new SelectedOrderViewModel(_orderViewModel.OrderModel);

            IsOrderSelected = true;

            //_deliverySystemModel.TakeOrder(Id);
            //OnOrderViewModelIsChanged();
        }
        public void OnExitSelected()
        {
            IsOrderSelected = false;

        }
        public OrdersCourierVM(DeliverySystemModel deliverySystemModel, IAuthenticator authenticator, IPriceBook priceBook/*, OrderBook orderBook*/)
        {
            //_assortmentModel = assortmentModel;
            _deliverySystemModel = deliverySystemModel;
            _authenticator = authenticator;
            _priceBook = priceBook;
            DelStatus = DeliveryStatus.HandedOver;
            IsOrderCommented = false;
            //_orderBook = orderBook;
            //_basket = _orderBook.GetBasketContent();
            //AddingPizzaViewModel.OnExitDelegate += OnExitEvent;
            //OrderLineViewModel.OnOrderLineIsChanged += OnOrderLineViewModelIsChanged;
            //OrderLineViewModel.OnOrderLineIsDeleted += OnOrderLineViewModelIsDeleted;
            //OrderLineViewModel.OnOrderLineIsUpdated += OnOrderLineViewModelIsUpdated;
            UserDTO user = authenticator.CurrentUser;
            OrderViewModel.OnOrderStateIsChanged += OnOrderViewModelIsChanged;
            OrderViewModel.OnOrderIsTaked += OnOrderViewModelIsTaked;
            OrderViewModel.OnOrderIsDelivered += OnOrderViewModelIsDelivered;
            OrderViewModel.OnOrderIsAbout += OnOrderViewModelIsAbout;
            CommentViewModel.OnExitDelegate += OnExitEvent;
            SelectedOrderViewModel.OnExitCommand += OnExitSelected;
            //Price = _basket.final_price.ToString();
            //Weight = _basket.weight.ToString();
            //Address = ((ClientDTO)user).AddressDel;
            //OrderModel.OnOrderIsChanged += OnOrderIsChanged;
        }
    }
}
