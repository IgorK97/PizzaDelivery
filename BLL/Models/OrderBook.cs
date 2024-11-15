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
    public class OrderBook
    {
        private readonly IAuthenticator _authenticator;
        private readonly IPriceBook _priceBook;
        private readonly IOrderService _orderService;
        private List<OrderModel> _orders;
        private int BasketId
        {
            get;set;
        }

        public OrderBook(IAuthenticator authenticator, IPriceBook priceBook, IOrderService orderServcie)
        {
            _authenticator = authenticator;
            _priceBook = priceBook;
            _orderService = orderServcie;
            _orders = new List<OrderModel>();
            
        }

        public void Load()
        {
            BasketId = _orderService.GetCurrentOrder(_authenticator.Id);

            List<OrderDto> oDto = _orderService.GetAllOrders(_authenticator.Id);
            foreach (OrderDto orderDto in oDto)
            {
                OrderModel om = new OrderModel(_priceBook, _orderService, orderDto);
                _orders.Add(om);
            }
        }

        public int GetBasketId()
        {
            var result = _orders.Where(i => i.Id == BasketId).FirstOrDefault();
            return (int) result.Id;
        }

        public IEnumerable<OrderLineModel> GetBasket()
        {
            var result = _orders.Where(i => i.Id == BasketId).Select(o => o.order_lines).FirstOrDefault();
            return result;
        }

        public OrderModel GetBasketContent()
        {
            //BasketId = _orderService.GetCurrentOrder(_authenticator.Id);

            OrderModel result = _orders.Where(i => i.Id == BasketId).FirstOrDefault();
            return result;
        }

        public void AddOrderLine(OrderLineModel orderLineModel)
        {
            OrderModel om = _orders.Where(i => i.Id == BasketId).FirstOrDefault();
            om.AddOrderLine(orderLineModel);
        }
        public void DeleteOrderLine(OrderLineModel orderLineModel)
        {
            OrderModel om = _orders.Where(i => i.Id == BasketId).FirstOrDefault();
            om.AddOrderLine(orderLineModel);
        }

        public bool MakeOrder()
        {
            return true;
        }
    }
}
