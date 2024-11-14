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
    public class BasketViewModel : ViewModelBase
    {
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
            IEnumerable<OrderLineModel> _lines = _basket.GetLines();

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
        private AddingPizzaViewModel addingPizza;
        public AddingPizzaViewModel AddingPizza
        {
            get
            {
                return addingPizza;
            }
            set
            {
                addingPizza = value;
                OnPropertyChanged(nameof(AddingPizza));

            }
        }

        public void OnOrderLineViewModelIsChanged()
        {
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Weight));
        }

        private bool _isPizzaSelected;
        public bool IsPizzaSelected
        {
            get
            {
                return _isPizzaSelected;
            }
            set
            {
                _isPizzaSelected = value;
                OnPropertyChanged(nameof(IsPizzaSelected));
            }
        }
        public void OnExitEvent()
        {
            IsPizzaSelected = false;

        }
        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        private string _price;
        public string Price
        {
            get
            {
                return _basket.final_price.ToString();
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private string _weight;
        public string Weight
        {
            get
            {
                return _basket.weight.ToString();
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return submitCommand;
            }
        }
        private readonly AssortmentModel _assortmentModel;
        private readonly IAuthenticator _authenticator;
        private readonly IPriceBook _priceBook;
        private readonly OrderBook _orderBook;
        private readonly OrderModel _basket;
        public BasketViewModel(AssortmentModel assortmentModel, IAuthenticator authenticator, IPriceBook priceBook, OrderBook orderBook)
        {
            _assortmentModel = assortmentModel;
            _authenticator = authenticator;
            _priceBook = priceBook;
            _orderBook = orderBook;
            _basket = _orderBook.GetBasketContent();
            AddingPizzaViewModel.OnExitDelegate += OnExitEvent;
            OrderLineViewModel.OnOrderLineIsChanged += OnOrderLineViewModelIsChanged;
            UserDTO user = authenticator.CurrentUser;
            //Price = _basket.final_price.ToString();
            //Weight = _basket.
            Address = ((ClientDTO)user).AddressDel;
        }
    }
}
