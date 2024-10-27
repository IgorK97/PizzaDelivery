﻿using DomainModel;
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

        public enum DeliveryStatus
        {
            NotPlaced = 1,
            Canceled = 2,
            IsBeingFormed = 3,
            AtTheCourier = 5,
            Delivered = 6,
            NotDelivered = 7,
            HandedOver = 8
        };

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

        public bool CancelOrder(int odId)
        {
            Order order = dbr.Orders.GetItem(odId);
            order.DelstatusId = (int)DeliveryStatus.Canceled;
            if (dbr.Save() > 0)
                return true;
            return false;
        }

        public bool SubmitOrder(int odId, string addressdel)
        {
            Order order = dbr.Orders.GetItem(odId);
            if (order != null)
            {
                if (order.FinalPrice == (decimal)0.00)
                    return false;
                order.DelstatusId = (int)DeliveryStatus.IsBeingFormed;
                order.Ordertime = DateTime.UtcNow;
                order.AddressDel = addressdel;
                if (dbr.Save() > 0)
                    return true;
            }
            return false;
        }

        public (decimal price, decimal weight) UpdateOrder(int odId)
        {
            decimal price, weight;
            price = dbr.OrderLines.GetList().Where(ol => ol.OrdersId == odId).Select(i => i.PositionPrice).Sum();
            weight = dbr.OrderLines.GetList().Where(ol => ol.OrdersId == odId).Select(i => i.Weight).Sum();
            Order order = dbr.Orders.GetItem(odId);
            order.Weight = weight;
            order.FinalPrice = price;
            if (dbr.Save() > 0)
                return (price, weight);
            throw new Exception("Ошибка обновления заказа");
        }


        public List<OrderDto> GetAllOrders(int ClientId)
        {
            return dbr.Orders.GetList().ToList().Where(i => i.ClientId == ClientId&&i.DelstatusId!=1).Select(i => new OrderDto(i)).OrderByDescending(i => i.ordertime).ToList();
        }

        public List<ManagerDto> GetAllManagers()
        {
            
            //var q = (from u in dbr.Users.GetList().ToList()
            //         join m in dbr.Managers on u.Id equals m.Id
            //         select new ManagerDto
            //         {
            //             Id = u.Id,
            //             first_name = u.FirstName,
            //             last_name = u.LastName,
            //             surname = u.Surname,
            //             login = u.Login,
            //             phone = m.Phone,
            //             email = m.Email,
            //             C_password = u.Password
            //         }).ToList();
            var q = dbr.Users.GetList().ToList().Join(dbr.Managers.GetList().ToList(), u => u.Id, m => m.Id, (_u, _m)
                => new ManagerDto
                {
                    Id = _u.Id,
                    first_name = _u.FirstName,
                    last_name = _u.LastName,
                    surname = _u.Surname,
                    login = _u.Login,
                    phone = _m.Phone,
                    email = _m.Email,
                    C_password = _u.Password
                }).ToList();
            return q;
        }

        public List<CouriersDto> GetAllCouriers()
        {
            var q = dbr.Users.GetList().ToList().Join(dbr.Couriers.GetList().ToList(), u => u.Id, c => c.Id, (_u, _c)
                => new CouriersDto
                {
                    Id = _u.Id,
                    first_name = _u.FirstName,
                    last_name = _u.LastName,
                    surname = _u.Surname,
                    login = _u.Login,
                    phone = _c.Phone,
                    email = _c.Email,
                    C_password = _u.Password
                }).ToList();
            return q;


            //return dbr.Couriers.GetList().ToList().Select(i => new CouriersDto(i)).ToList();
        }
    }
}
