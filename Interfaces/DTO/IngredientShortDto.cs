using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IngredientShortDto
    {
        public IngredientShortDto()
        {

        }
        public int Id { get; set; }

        public string C_name { get; set; }

        public decimal price { get; set; }

        public decimal weight { get; set; }


        public bool active { get; set; }

        public IngredientShortDto(int id, string C_name, int price, int weight)
        {
            Id = id;
            this.C_name = C_name;
            this.price = price;
            this.weight = weight;
            active = false;
        }
    }
}
