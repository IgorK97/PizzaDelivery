using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class OrdersByMonth
    {
        public int order_id { get; set; }
        public string? courier_id { get; set; }
        public DateTime? Date { get; set; }
    }
}
