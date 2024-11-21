using BLL.Models;
using DTO;
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
    public delegate void OrderStateViewModelIsChanged();
    public delegate void OrderViewModelIsTaked(int id);
    public delegate void OrderViewModelIsDelivered(OrderViewModel _orderViewModel);
    public delegate void OrderViewModelIsAbout(OrderViewModel _orderViewModel);

    public class OrderViewModel : ViewModelBase

    {
        public static event OrderViewModelIsDeleted OnOrderIsDeleted;
        public static event OrderStateViewModelIsChanged OnOrderStateIsChanged;
        public static event OrderViewModelIsTaked OnOrderIsTaked;
        public static event OrderViewModelIsDelivered OnOrderIsDelivered;
        public static event OrderViewModelIsAbout OnOrderIsAbout;
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
        private ICommand changeStatus;
        public ICommand ChangeStatus
        {
            get
            {
                return changeStatus ??= new Commands.DelegateCommand(obj =>
                {
                    _orderModel.ChangeStatus((DeliveryStatus)obj);
                    OnOrderStateIsChanged?.Invoke();
                });
            }
        }
        private ICommand takeOrder;
        public ICommand TakeOrder
        {
            get
            {
                return changeStatus ??= new Commands.DelegateCommand(obj =>
                {
                    //_orderModel.ChangeStatus((DeliveryStatus)obj);
                    //OnOrderStateIsChanged?.Invoke();
                    OnOrderIsTaked?.Invoke(Id);
                });
            }
        }
        private ICommand delOrder;
        public ICommand DelOrder
        {
            get
            {
                return delOrder ??= new Commands.DelegateCommand(obj =>
                {
                    OnOrderIsDelivered?.Invoke(this);
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
        private DTO.DeliveryStatus _orderStatus;
        public DTO.DeliveryStatus OrderStatus
        {
            get
            {
                return _orderStatus;
            }
            set
            {
                _orderStatus = value;
                OnPropertyChanged(nameof(OrderStatus));
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
            Id = (int)om.Id;
            Number = om.Id.ToString();
            Address = om.address_del.ToString();
            Weight = om.weight.ToString();
            Cost = om.final_price.ToString();
            OrderDate = om.ordertime.ToString();
            DeliveryDate = om.deliverytime.ToString();
            Status = ((DTO.DeliveryStatus)om.delstatusId).ToString();
            OrderStatus = (DTO.DeliveryStatus)om.delstatusId;
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
        private ICommand aboutOrder;
        public ICommand AboutOrder
        {
            get
            {
                return aboutOrder ??= new Commands.DelegateCommand(obj =>
                {
                    OnOrderIsAbout?.Invoke(this);
                });
            }
            
        }
    }
}
