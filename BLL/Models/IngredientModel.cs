using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }

        public string C_name { get; set; }

        public decimal price_per_gram { get; set; }

        public decimal small { get; set; }

        public decimal medium { get; set; }

        public decimal big { get; set; }

        public bool active { get; set; }
        public byte[]? ingrimage { get; set; }
    }
}
