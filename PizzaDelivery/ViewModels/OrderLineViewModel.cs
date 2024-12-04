 using BLL.Models;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public delegate void OrderLineViewModelIsChanged();
    public delegate void OrderLineViewModelIsDeleted();
    public delegate void OrderLineViewModelIsUpdated(OrderLineViewModel olm);



    public class OrderLineViewModel :ViewModelBase
    {
        public static event OrderLineViewModelIsChanged OnOrderLineIsChanged;
        public static event OrderLineViewModelIsDeleted OnOrderLineIsDeleted;
        public static event OrderLineViewModelIsUpdated OnOrderLineIsUpdated;



        private readonly OrderLineModel _orderLineModel;
        public OrderLineModel OrderLineModel
        {
            get
            {
                return _orderLineModel;
            }
        }
        public int Id { get; set; }
        public int Quantity { 
            get 
            {
                return _orderLineModel.Quantity;
            }
            set
            {
                _orderLineModel.Quantity = value;
                decimal price, weight;
                (price, weight) = _orderLineModel.CalculateLine();
                Weight = weight.ToString();
                Price = price.ToString();
                OnPropertyChanged(nameof(Quantity));
                //OnPropertyChanged(nameof(Price));
                //OnPropertyChanged(nameof(Weight));
            }
        }
        private ICommand deleteYourself;
        public ICommand DeleteYourself
        {
            get
            {
                return deleteYourself ??= new Commands.DelegateCommand(obj =>
                {
                    _orderLineModel.DeleteYourself();
                    OnOrderLineIsDeleted?.Invoke();
                });
            }
        }
        private bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public void UpdateProperties()
        {
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Weight));
            OnPropertyChanged(nameof(isActive));
        }

        private ICommand updateYourself;
        public ICommand UpdateYourself
        {
            get
            {
                return updateYourself ??= new Commands.DelegateCommand(obj =>
                {
                    OnOrderLineIsUpdated?.Invoke(this);
                });
            }
        }

        private string _price;
        public string Price {
            get
            {
                return _orderLineModel.Position_price.ToString();
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
                return _orderLineModel.Weight.ToString();
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public string Name => _orderLineModel.Pizza.C_name;
        public byte[]? Image => _orderLineModel.Pizza.pizzaimage;
        private string _ingrList;
        public string IngrList
        {
            get
            {
                return _ingrList;
            }
            set
            {
                _ingrList = value;
                OnPropertyChanged(nameof(IngrList));
            }
        }
        public OrderLineViewModel(OrderLineModel olm)
        {
            _orderLineModel = olm;
            Id = olm.Id;
            isActive = olm.Active;
            IngrList = _orderLineModel.GetStringIngrs();
            //Price = olm.Position_price.ToString();
            //Weight = olm.Weight.ToString();
        }
    }
}
