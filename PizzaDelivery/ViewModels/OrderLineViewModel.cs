using BLL.Models;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PizzaDelivery.ViewModels
{
    public delegate void OrderLineViewModelIsChanged();

    public class OrderLineViewModel :ViewModelBase
    {
        public static event OrderLineViewModelIsChanged OnOrderLineIsChanged;

        private readonly OrderLineModel _orderLineModel;
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
        private string _price;
        public string Price {
            get
            {
                return _price;
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
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public string Name => _orderLineModel.Pizza.C_name;
        public byte[]? Image => _orderLineModel.Pizza.pizzaimage;

        public OrderLineViewModel(OrderLineModel olm)
        {
            _orderLineModel = olm;
            Id = olm.Id;
            Price = olm.Position_price.ToString();
            Weight = olm.Weight.ToString();
        }
    }
}
