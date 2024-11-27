using DomainModel;
using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderManagementService : IOrderManagementService
    {
        private IDbRepos dbr;
        //PizzaDeliveryContext db;
        public OrderManagementService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        public List<OrderDto> GetAllOrders()
        {
            return dbr.Orders.GetList().ToList()
                .Select(i => new OrderDto(i)).OrderByDescending(i => i.ordertime).ToList();

        }

        public OrderDto GetOrder(OrderDto o)
        {
            return dbr.Orders.GetList().Where(i => i.Id == o.Id).Select(i =>
            new OrderDto(i)).FirstOrDefault();
        }

        public bool UpdateOrder(OrderDto odto)
        {
            Order order = dbr.Orders.GetItem((int)odto.Id);
            if (order != null)
            {
                order.DelstatusId = odto.delstatusId;
                order.CourierId = odto.courierId;
                order.ManagersId = odto.managerId;
                order.Comment = odto.comment;
                if (odto.delstatusId == (int)DeliveryStatus.Delivered)
                    order.Deliverytime = odto.deliverytime;
                dbr.Orders.Update(order);
                //List<OrderLine> lines = new List<OrderLine>();
                //foreach (var pId in odto.order_lines)
                //{
                //    OrderLine ingr = dbr.OrderLines.GetItem(pId.Id);
                //    lines.Add(ingr);
                //}
                //order.OrderLines = lines;
                //if (dbr.Save() > 0)
                //    return true;
                //return false;
            }
            return true;
        }
    }
}
