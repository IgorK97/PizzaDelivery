using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }

        public string C_name { get; set; }

        public bool active { get; set; }

        public string description { get; set; }
        public byte[]? pizzaimage { get; set; }

        public IEnumerable<IngredientModel> listedingredients { get; set; }
    }
}
