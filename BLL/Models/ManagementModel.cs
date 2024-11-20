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
    public class ManagementModel
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
        public ManagementModel(IAuthenticator authenticator, IPriceBook priceBook, IOrderManagementService orderServcie)
        {
            _authenticator = authenticator;
            _priceBook = priceBook;
            _orderManagementService = orderServcie;
            _orders = new List<OrderModel>();

        }

        public List<OrderModel> GetNecesseryOrderList(DeliveryStatus ds)
        {
            return Orders.Where(o => o.delstatusId == (int)ds).ToList();
        }
        public void Load()
        {
            //BasketId = _orderService.GetCurrentOrder(_authenticator.Id);
            _orders = new List<OrderModel>();
            List<OrderDto> oDto = _orderManagementService.GetAllOrders();
            foreach (OrderDto orderDto in oDto)
            {
                OrderModel om = new OrderModel(_priceBook, _orderManagementService, orderDto);
                _orders.Add(om);
            }
        }
    }
}
