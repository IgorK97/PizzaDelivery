﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum DeliveryStatus
    {
        NotPlaced = 1,
        Canceled = 2,
        IsBeingFormed = 3,
        AtTheCourier = 5,
        Delivered = 6,
        NotDelivered = 7,
        HandedOver = 8,
        IsCooking = 9
    };
    public class OrderDto
    {
        
        public OrderDto()
        {

        }

        public int? Id { get; set; }

        public int clientId { get; set; }
        public int? courierId { get; set; }
        public int? managerId { get; set; }
        public decimal final_price { get; set; }

        public string address_del { get; set; }

        public decimal weight { get; set; }
        public DateTime? ordertime { get; set; }
        public DateTime? deliverytime { get; set; }
        public int delstatusId { get; set; }
        public string? comment { get; set; }

        public List<OrderLineDto> order_lines { get; set; }
        public OrderDto(Order o)
        {
            Id = o.Id;
            clientId = o.ClientId;
            courierId = o.CourierId;
            managerId = o.ManagersId;
            final_price = o.FinalPrice;
            address_del = o.AddressDel;
            weight = o.Weight;
            ordertime = o.Ordertime;
            deliverytime = o.Deliverytime;
            delstatusId = o.DelstatusId;
            comment = o.Comment;
            order_lines = new List<OrderLineDto>();
            foreach(OrderLine ol in o.OrderLines)
            {
                OrderLineDto olDto = new OrderLineDto(ol);
                order_lines.Add(olDto);
            }
            //order_linesIds = o.OrderLines.Select(i => i.Id).ToList();
        }
    }
}
