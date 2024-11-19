using BLL.Models;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public delegate void OrderViewModelIsDeleted();

    public class OrderViewModel : ViewModelBase

    {
        public static event OrderViewModelIsDeleted OnOrderIsDeleted;

        private readonly OrderModel _orderModel;
        public OrderModel OrderModel
        {
            get
            {
                return _orderModel;
            }
        }
        public int Id { get; set; }
        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ??= new Commands.DelegateCommand(obj =>
                {
                    _orderModel.CancelYourself();
                    OnOrderIsDeleted?.Invoke();
                });
            }
        }
        private bool _isDelivered;
        public bool IsDelivered
        {
            get
            {
                return _isDelivered;
            }
            set
            {
                _isDelivered = value;
                OnPropertyChanged(nameof(IsDelivered));
            }
        }
        private bool _isCanceled;
        public bool IsCanceled
        {
            get
            {
                return _isCanceled;
            }
            set
            {
                _isCanceled = value;
                OnPropertyChanged(nameof(IsCanceled));
            }
        }
        private string _deliveryDate;
        public string DeliveryDate
        {
            get
            {
                return _deliveryDate;
            }
            set
            {
                _deliveryDate = value;
                OnPropertyChanged(nameof(DeliveryDate));
            }
        }
        private string _orderDate;
        public string OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }
        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
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
        private string _number;
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
        public OrderViewModel(OrderModel om)
        {
            _orderModel = om;
            Number = om.Id.ToString();
            Address = om.address_del.ToString();
            Weight = om.weight.ToString();
            Cost = om.final_price.ToString();
            OrderDate = om.ordertime.ToString();
            DeliveryDate = om.deliverytime.ToString();
            Status = ((DTO.DeliveryStatus)om.delstatusId).ToString();
            if (om.delstatusId == 6)
            {
                IsDelivered = true;
                IsCanceled = false;
            }
            else
            {
                IsDelivered = false;
                if (om.delstatusId == 2 || om.delstatusId == 7)
                    IsCanceled = false;
                else
                    IsCanceled = true;
            }
        }
    }
}
