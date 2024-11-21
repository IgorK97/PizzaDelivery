using BLL.Models;
using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public delegate void ExitCommentDelegate();

    public class CommentViewModel : ViewModelBase
    {
        public OrderModel _orderModel;
        public static event ExitCommentDelegate OnExitDelegate;
        public CommentViewModel(OrderModel orderModel, bool p)
        {
            _orderModel = orderModel;
            Comment = orderModel.comment;
            IsChangeable = p;
            success = true;
            OnPropertyChanged(nameof(IsSuccess));
            OnPropertyChanged(nameof(IsNotSuccess));
        }
        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand ??= new Commands.DelegateCommand(obj =>
                {
                    OnExitDelegate?.Invoke();
                });
            }
        }
        private ICommand save;
        public ICommand Save
        {
            get
            {
                return save ??= new Commands.DelegateCommand(obj =>
                {
                    _orderModel.comment = _comment;
                    if (success)
                        _orderModel.delstatusId = (int)DeliveryStatus.Delivered;
                    else
                        _orderModel.delstatusId = (int)DeliveryStatus.NotDelivered;
                    _orderModel.UpdateOrder();
                    OnExitDelegate?.Invoke();
                });
            }
        }
        private ICommand updateSuccess;
        public ICommand UpdateSuccess
        {
            get
            {
                return updateSuccess ??= new Commands.DelegateCommand(obj =>
                {
                    DeliveryStatus ds = (DeliveryStatus)obj;
                    if (ds == DeliveryStatus.Delivered)
                        success = true;
                    else
                        success = false;
                    OnPropertyChanged(nameof(IsSuccess));
                    OnPropertyChanged(nameof(IsNotSuccess));
                });
            }
        }
        private bool isChangeable;
        public bool IsChangeable
        {
            get
            {
                return isChangeable;
            }
            set
            {
                isChangeable = value;
                OnPropertyChanged(nameof(IsChangeable));
            }
        }
        private bool success;
        public bool IsSuccess
        {
            get
            {
                return success == true;
            }
        }
        public bool IsNotSuccess
        {
            get
            {
                return success == false;
            }
        }
    }
}
