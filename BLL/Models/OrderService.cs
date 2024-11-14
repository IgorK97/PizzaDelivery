using DomainModel;
using DTO;
using DAL;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using Interfaces.Services;

namespace BLL.Models
{
    public class OrderService : IOrderService
    {
        private IDbRepos dbr;
        //PizzaDeliveryContext db;
        public OrderService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        public bool UpdateOrder(OrderDto odto)
        {
            Order order = dbr.Orders.GetItem((int)odto.Id);
            if (order != null)
            {
                order.Ordertime = odto.ordertime;
                order.AddressDel = odto.address_del;
                order.DelstatusId = odto.delstatusId;
                order.FinalPrice = odto.final_price;
                order.Weight = odto.weight;
                List<OrderLine> lines = new List<OrderLine>();
                foreach (var pId in odto.order_lines)
                {
                    OrderLine ingr = dbr.OrderLines.GetItem(pId.Id);
                    lines.Add(ingr);
                }
                order.OrderLines = lines;
                if (dbr.Save() > 0)
                    return true;
                return false;
            }
            return false;
        }

        public OrderDto GetOrder(int Id)
        {
            return dbr.Orders.GetList().Where(i => i.Id == Id && i.DelstatusId==1).Select(i =>
            new OrderDto(i)).FirstOrDefault();
        }

        public int GetCurrentOrder(int ClientId)
        {
            //OrderDto oid = (OrderDto) db.orders.Where(i =>
            //i.clientId == ClientId && i.delstatusId == 2);
            //return oid;
            int oid = 0;
            oid = dbr.Orders.GetList().Where(i => i.ClientId == ClientId && i.DelstatusId == (int) DeliveryStatus.NotPlaced/*1*/).
                Select(o => o.Id).FirstOrDefault();
            //Если такого нет, то создать такой
            if (oid == 0)
            {
                bool s = MakeOrder(ClientId/*, DeliveryStatus.NotPlaced*/);
                oid = dbr.Orders.GetList().Where(i => i.ClientId == ClientId && i.DelstatusId == (int) DeliveryStatus.NotPlaced/* 1*/).
                Select(o => o.Id).FirstOrDefault();
            }
            //Order res = db.Orders.Find(oid);
            //OrderDto resord = new OrderDto()
            //{

            //}
            return oid;
        }

        

        public bool MakeOrder(int ClientId/*, DeliveryStatus delstatus*/)
        {
            Order order = new Order
            {
                ClientId = ClientId,
                FinalPrice = 0,
                Weight = 0,
                DelstatusId = 1,
                AddressDel = "",
                Comment = ""
            };

            dbr.Orders.Create(order);
            if (dbr.Save() > 0)
                return true;
            return false;
        }

        //public bool CancelOrder(int odId)
        //{
        //    Order order = dbr.Orders.GetItem(odId);
        //    order.DelstatusId = (int)DeliveryStatus.Canceled;
        //    if (dbr.Save() > 0)
        //        return true;
        //    return false;
        //}

        //public bool SubmitOrder(int odId, string addressdel)
        //{
        //    Order order = dbr.Orders.GetItem(odId);
        //    if (order != null)
        //    {
        //        if (order.FinalPrice == (decimal)0.00)
        //            return false;
        //        order.DelstatusId = (int)DeliveryStatus.IsBeingFormed;
        //        order.Ordertime = DateTime.UtcNow;
        //        order.AddressDel = addressdel;
        //        if (dbr.Save() > 0)
        //            return true;
        //    }
        //    return false;
        //}

        //public (decimal price, decimal weight) UpdateOrder(int odId)
        //{
        //    decimal price, weight;
        //    price = dbr.OrderLines.GetList().Where(ol => ol.OrdersId == odId).Select(i => i.PositionPrice).Sum();
        //    weight = dbr.OrderLines.GetList().Where(ol => ol.OrdersId == odId).Select(i => i.Weight).Sum();
        //    Order order = dbr.Orders.GetItem(odId);
        //    order.Weight = weight;
        //    order.FinalPrice = price;
        //    if (dbr.Save() > 0)
        //        return (price, weight);
        //    throw new Exception("Ошибка обновления заказа");
        //}


        public List<OrderDto> GetAllOrders(int ClientId)
        {
            
            return dbr.Orders.GetList().ToList().Where(i => i.ClientId == ClientId /*&& i.DelstatusId != 1*/)
                .Select(i => new OrderDto(i)).OrderByDescending(i => i.ordertime).ToList();
            
        }
        public bool Save()
        {
            if (dbr.Save() > 0) return true;
            return false;
        }

        public void CreateOrderLine(OrderLineDto p)
        {
            List<Ingredient> addedingredients = new List<Ingredient>();
            foreach (var pId in p.addedingredients)
            {
                Ingredient ingr = dbr.Ingredients.GetItem(pId.Id);
                addedingredients.Add(ingr);
            }
            dbr.OrderLines.Create(new OrderLine()
            {
                PositionPrice = p.position_price,
                OrdersId = p.ordersId,
                Custom = p.custom,
                Weight = p.weight,
                PizzaId = p.pizzaId,
                PizzaSizesId = p.pizza_sizesId,
                Quantity = p.quantity,
                Ingredients = addedingredients
            });
            Save();
            //dbr.order_lines.Attach(p);
        }

        public void UpdateOrderLine(OrderLineDto p)
        {
            //List<Ingredient> addedingredients = new List<Ingredient>();
            //foreach (var pId in p.addedingredientsId)
            //{
            //    Ingredient ingr = dbr.Ingredients.GetItem(pId);
            //    addedingredients.Add(ingr);
            //}
            //OrderLine ol = dbr.OrderLines.GetItem(p.Id);
            //ol.Weight = p.weight;
            //ol.Custom = p.custom;
            //ol.PizzaId = p.pizzaId;
            //ol.PositionPrice = p.position_price;
            //ol.PizzaSizesId = p.pizza_sizesId;
            //ol.Quantity = p.quantity;
            //ol.OrdersId = p.ordersId;
            //ol.Ingredients = addedingredients;
            //Save();
        }

        public void DeleteOrderLine(int id)
        {
            //OrderLine p = dbr.OrderLines.GetItem(id);
            //if (p != null)
            //{
            dbr.OrderLines.Delete(id);
            //Save();
            //}
        }

        //public List<ManagerDto> GetAllManagers()
        //{

        //    var q = dbr.Users.GetList().ToList().Join(dbr.Managers.GetList().ToList(), u => u.Id, m => m.Id, (_u, _m)
        //        => new ManagerDto
        //        {
        //            Id = _u.Id,
        //            FirstName = _u.FirstName,
        //            LastName = _u.LastName,
        //            Surname = _u.Surname,
        //            Login = _u.Login,
        //            Phone = _m.Phone,
        //            Email = _m.Email,
        //            Password = _u.Password
        //        }).ToList();
        //    return q;
        //}

        //public List<CouriersDto> GetAllCouriers()
        //{
        //    var q = dbr.Users.GetList().ToList().Join(dbr.Couriers.GetList().ToList(), u => u.Id, c => c.Id, (_u, _c)
        //        => new CouriersDto
        //        {
        //            Id = _u.Id,
        //            FirstName = _u.FirstName,
        //            LastName = _u.LastName,
        //            Surname = _u.Surname,
        //            Login = _u.Login,
        //            Phone = _c.Phone,
        //            Email = _c.Email,
        //            Password = _u.Password
        //        }).ToList();
        //    return q;


        //    //return dbr.Couriers.GetList().ToList().Select(i => new CouriersDto(i)).ToList();
        //}

        
        //public bool Save()
        //{
        //    if (dbr.Save() > 0) return true;
        //    return false;
        //}
    }
}
