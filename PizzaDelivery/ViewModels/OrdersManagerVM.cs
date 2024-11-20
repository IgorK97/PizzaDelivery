using BLL.Models;
using DTO;
using Interfaces.Services;
using PizzaDelivery.State.Authenticators;
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
    public class OrdersManagerVM : ViewModelBase
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
            //IEnumerable<OrderLineModel> _lines = _basket.GetLines();

            //foreach (OrderLineModel olm in _lines)
            //{
            //    OrderLineViewModel olvm = new OrderLineViewModel(olm);
            //    _orderscollection.Add(olvm);
            //}
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
            //if (_selectedOrder != null) //Когда будут диспоуз вьюмодел делать, убрать
            //    _selectedOrder.UpdateProperties();
            //OnPropertyChanged(nameof(SelectedLine));
            //OnPropertyChanged(nameof(LinesCollection));
            //OnPropertyChanged(nameof(Price));
            //OnPropertyChanged(nameof(Weight));
        }
        


        private ICommand selectStatus;
        public ICommand SelectStatus
        {
            get
            {
                return selectStatus;
            }
        }

        
        private readonly AssortmentModel _assortmentModel;
        private readonly IAuthenticator _authenticator;
        private readonly IPriceBook _priceBook;
        private readonly OrderBook _orderBook;
        private OrderModel _basket;
        
        public OrdersManagerVM(AssortmentModel assortmentModel, IAuthenticator authenticator, IPriceBook priceBook, OrderBook orderBook)
        {
            _assortmentModel = assortmentModel;
            _authenticator = authenticator;
            _priceBook = priceBook;
            _orderBook = orderBook;
            _basket = _orderBook.GetBasketContent();
            //AddingPizzaViewModel.OnExitDelegate += OnExitEvent;
            //OrderLineViewModel.OnOrderLineIsChanged += OnOrderLineViewModelIsChanged;
            //OrderLineViewModel.OnOrderLineIsDeleted += OnOrderLineViewModelIsDeleted;
            //OrderLineViewModel.OnOrderLineIsUpdated += OnOrderLineViewModelIsUpdated;
            UserDTO user = authenticator.CurrentUser;
            //Price = _basket.final_price.ToString();
            //Weight = _basket.weight.ToString();
            //Address = ((ClientDTO)user).AddressDel;
            //OrderModel.OnOrderIsChanged += OnOrderIsChanged;
        }
    }
}
