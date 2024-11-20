using DTO;
using Interfaces.Services;
using PizzaDelivery.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DeliverySystemModel
    {
        private readonly IAuthenticator _authenticator;
        private readonly IPriceBook _priceBook;
        private readonly IOrderManagementService _orderManagementService;
        private List<OrderModel> _orders;
        public List<OrderModel> Orders
        {
            get
            {
                return _orders;
            }
        }
        public DeliverySystemModel(IAuthenticator authenticator, IPriceBook priceBook, IOrderManagementService orderServcie)
        {
            _authenticator = authenticator;
            _priceBook = priceBook;
            _orderManagementService = orderServcie;
            _orders = new List<OrderModel>();

        }

        public void TakeOrder(int OrderId)
        {
            int cid = _authenticator.Account.Id;

            OrderModel om = _orders.Where(o => o.Id == OrderId).FirstOrDefault();
            om.TakeOrderCourier(cid);
        }

        public List<OrderModel> GetNecesseryOrderList(DeliveryStatus ds)
        {
            return Orders.Where(o => o.delstatusId == (int)ds).ToList();
        }
        public void Load()
        {
            int cid = _authenticator.Account.Id;
            //BasketId = _orderService.GetCurrentOrder(_authenticator.Id);
            _orders = new List<OrderModel>();
            List<OrderDto> oDto = _orderManagementService.GetAllOrders().Where( o =>
            o.delstatusId!= (int)DeliveryStatus.NotPlaced &&
            o.delstatusId!=(int)DeliveryStatus.IsBeingFormed &&
            o.delstatusId!=(int)DeliveryStatus.IsCooking
            || (o.delstatusId==(int)DeliveryStatus.Canceled ||
            o.delstatusId==(int)DeliveryStatus.AtTheCourier ||
            o.delstatusId==(int)DeliveryStatus.Delivered ||
            o.delstatusId==(int)DeliveryStatus.NotDelivered)&&
            o.courierId==cid).ToList();
            foreach (OrderDto orderDto in oDto)
            {
                OrderModel om = new OrderModel(_priceBook, _orderManagementService, orderDto);
                _orders.Add(om);
            }
        }
    }
}
