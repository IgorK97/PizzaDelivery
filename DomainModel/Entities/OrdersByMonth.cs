using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class OrdersByMonth
    {
        //public int order_id { get; set; }
        //public string? courier_id { get; set; }
        //public DateTime? Date { get; set; }
        //public int Id { get; set; }

        public int pizza_id { get; set; }
        public string pizza_name { get; set; }
        public int total_quantity { get; set; }
        public decimal total_cost { get; set; }
    }
}
