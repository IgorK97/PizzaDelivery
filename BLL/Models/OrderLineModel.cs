using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrderLineModel
    {
        public int Id { get; set; }
        public int ordersId { get; set; }
        public int pizzaId { get; set; }
        public int quantity { get; set; }
        public bool custom { get; set; }
        public decimal position_price { get; set; }
        public int pizza_sizesId { get; set; }
        public decimal weight { get; set; }

        public PizzaModel pizza { get; set; }
        public IEnumerable<IngredientModel> addedingredients { get; set; }
    }
}
