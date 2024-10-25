using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PizzaDto
    {
        public PizzaDto()
        {

        }

        public int Id { get; set; }

        public string C_name { get; set; }

        public bool active { get; set; }

        public string description { get; set; }
        public byte[]? pizzaimage { get; set; }

        public List<int> listedingredientsIds { get; set; }

        public PizzaDto(Pizza p)
        {
            Id = p.Id;
            C_name = p.Name;
            active = p.Active;
            description = p.Description;
            pizzaimage = p.Pizzaimage;
            listedingredientsIds = p.Ingredients.Select(i => i.Id).ToList();
        }
    }
}
