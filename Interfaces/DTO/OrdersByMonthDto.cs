using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class OrdersByMonthDto
    {
        //public int order_id { get; set; }
        //public string? courier_id { get; set; }
        //public DateTime? Date { get; set; }
        public int pizzaId { get; set; }
        public string pizzaName { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
    }
}
