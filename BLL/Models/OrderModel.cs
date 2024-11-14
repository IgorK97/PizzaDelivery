using DomainModel;
using DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrderModel
    {
        private readonly IPriceBook _priceBook;
        private readonly IOrderService _orderService;

        public int? Id { get; set; }

        public int clientId { get; set; }
        public int? courierId { get; set; }

        public decimal final_price { get; set; }

        public string address_del { get; set; }

        public decimal weight { get; set; }
        public DateTime? ordertime { get; set; }
        public DateTime? deliverytime { get; set; }
        public int delstatusId { get; set; }
        public string? comment { get; set; }


        public List<OrderLineModel> order_lines { get; set; }
        public IEnumerable<OrderLineModel> GetLines()
        {
            return order_lines;
        }
        public OrderModel(IPriceBook priceBook, IOrderService orderService, OrderDto o)
        {
            _priceBook = priceBook;
            _orderService = orderService;
            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto oldto in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, oldto);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
            OrderLineModel.OnOrderLineIsChanged += OnOrderLineChanged;
            OrderLineModel.OnOrderLineIsDeleted += DeleteOrderLine;
        }
        public int LineCount{get;set;}
        public void AddOrderLine(OrderLineModel orderLineModel)
        {
            List<IngredientDto> listedingr = new List<IngredientDto>();
            foreach(IngredientModel ingrm in orderLineModel.addedingredients)
            {
                IngredientDto ingredientDto = new IngredientDto
                {
                    Id = ingrm.Id

                };
                listedingr.Add(ingredientDto);
            }
            OrderLineDto oldto = new OrderLineDto
            {
                position_price = orderLineModel.Position_price,
                ordersId = (int)Id,
                custom = orderLineModel.Custom,
                weight = orderLineModel.Weight,
                pizzaId = orderLineModel.Pizza.Id,
                pizza_sizesId = orderLineModel.Pizza_sizesId,
                quantity = orderLineModel.Quantity,
                addedingredients = listedingr,
                Pizza = new PizzaDto
                {
                    Id = orderLineModel.Pizza.Id
                }
            };
            _orderService.CreateOrderLine(oldto);
            OrderDto o = _orderService.GetOrder((int)Id);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
        }

        public void OnOrderLineChanged(int id)
        {
            if (id == Id)
            {
                CalculateOrderPrice();
                CalculateOrderWeight();
            }
        }

        public void CalculateOrderPrice()
        {
            final_price=order_lines.Select(ol => ol.Position_price).Sum();

        }

        public void CalculateOrderWeight()
        {
            weight = order_lines.Select(ol => ol.Weight).Sum();
        }

        public void DeleteOrderLine(int OrderId, int OrderLineId)
        {
            if (OrderId == Id)
            {

            }

        }
    }
}
