using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDto
    {
        public OrderDto()
        {

        }

        public int? Id { get; set; }

        public int clientId { get; set; }
        public int? courierId { get; set; }

        public decimal final_price { get; set; }

        public string address_del { get; set; }

        public decimal weight { get; set; }
        public DateTime? ordertime { get; set; }
        public DateTime? deliverytime { get; set; }
        public int delstatusId { get; set; }
        public string? comment { get; set; }

        public List<int> order_linesIds { get; set; }
        public OrderDto(Order o)
        {
            Id = o.Id;
            clientId = o.ClientId;
            courierId = o.CourierId;
            final_price = o.FinalPrice;
            address_del = o.AddressDel;
            weight = o.Weight;
            ordertime = o.Ordertime;
            deliverytime = o.Deliverytime;
            delstatusId = o.DelstatusId;
            comment = o.Comment;
            order_linesIds = o.OrderLines.Select(i => i.Id).ToList();
        }
    }
}
