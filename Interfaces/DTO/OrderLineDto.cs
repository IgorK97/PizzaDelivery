using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderLineDto
    {
        public OrderLineDto()
        {

        }

        public int Id { get; set; }
        public int ordersId { get; set; }
        public int pizzaId { get; set; }
        public int quantity { get; set; }
        public bool custom { get; set; }
        public decimal position_price { get; set; }
        public int pizza_sizesId { get; set; }
        public decimal weight { get; set; }

        public virtual List<int> addedingredientsId { get; set; }
        public OrderLineDto(OrderLine ol)
        {
            Id = ol.Id;
            ordersId = ol.OrdersId;
            custom = ol.Custom;
            position_price = ol.PositionPrice;
            pizzaId = ol.PizzaId;
            quantity = ol.Quantity;
            pizza_sizesId = ol.PizzaSizesId;
            weight = ol.Weight;
            addedingredientsId = ol.Ingredients.Select(i => i.Id).ToList();
        }
    }
}
