using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IngredientDto
    {
        public IngredientDto()
        {

        }
        public int Id { get; set; }

        public string C_name { get; set; }

        public decimal price_per_gram { get; set; }

        public decimal small { get; set; }

        public decimal medium { get; set; }

        public decimal big { get; set; }

        public bool active { get; set; }
        public byte[]? ingrimage { get; set; }

        public IngredientDto(Ingredient i)
        {
            Id = i.Id;
            C_name = i.Name;
            price_per_gram = i.PricePerGram;
            small = i.Small;
            medium = i.Medium;
            big = i.Big;
            active = i.Active;
            ingrimage = i.Ingrimage;
        }
    }
}
