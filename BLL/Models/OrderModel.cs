﻿using DomainModel;
using DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public delegate void OrderIsChanged();
    public enum SubmitOrderResult
    {
        Success=1,
        Failed=2,
        FailedOrderComponent=3
    }
    
   
    public class OrderModel
    {
        private readonly IPriceBook _priceBook;
        private readonly IOrderService _orderService;
        private readonly IOrderManagementService _orderManagementService;
        public static event OrderIsChanged OnOrderIsChanged;

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



        public List<OrderLineModel> order_lines { get; set; }
        public IEnumerable<OrderLineModel> GetLines()
        {
            return order_lines;
        }
        public void TakeOrderCourier(int CourierId)
        {
            OrderDto newodto = new OrderDto();


            newodto.Id = Id;
            newodto.address_del = address_del;
            newodto.delstatusId = (int)DeliveryStatus.AtTheCourier;
            newodto.courierId = CourierId;
            newodto.managerId = managerId;
            newodto.final_price = final_price;
            newodto.weight = weight;

            _orderManagementService.UpdateOrder(newodto);
            OrderDto o = _orderManagementService.GetOrder(newodto);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
        }
        public void UpdateOrder()
        {
            OrderDto newodto = new OrderDto();


            newodto.Id = Id;
            newodto.address_del = address_del;
            newodto.delstatusId = delstatusId;
            newodto.managerId = managerId;
            newodto.courierId = courierId;
            if (delstatusId == (int)DeliveryStatus.Delivered)
                newodto.deliverytime = DateTime.UtcNow;
            else
                newodto.deliverytime = null;
            newodto.final_price = final_price;
            newodto.weight = weight;
            newodto.comment = comment;

            _orderManagementService.UpdateOrder(newodto);
            OrderDto o = _orderManagementService.GetOrder(newodto);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
        }
        public void TakeOrderManager(int ManagerId)
        {
            OrderDto newodto = new OrderDto();


            newodto.Id = Id;
            newodto.address_del = address_del;
            newodto.delstatusId = (int)DeliveryStatus.IsCooking;
            newodto.managerId = ManagerId;
            newodto.final_price = final_price;
            newodto.weight = weight;

            _orderManagementService.UpdateOrder(newodto);
            OrderDto o = _orderManagementService.GetOrder(newodto);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
        }
        public void ChangeStatus(DeliveryStatus ds)
        {
            OrderDto newodto = new OrderDto();


            newodto.Id = Id;
            newodto.address_del = address_del;
            newodto.delstatusId = (int)ds;
            newodto.final_price = final_price;
            newodto.weight = weight;
            newodto.courierId = courierId;
            newodto.managerId = managerId;
            _orderManagementService.UpdateOrder(newodto);
            OrderDto o = _orderManagementService.GetOrder(newodto);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
        }
        public OrderModel(IPriceBook priceBook, IOrderService orderService, OrderDto o)
        {
            _priceBook = priceBook;
            _orderService = orderService;
            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto oldto in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, oldto);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
            OrderLineModel.OnOrderLineIsChanged += OnOrderLineChanged;
            OrderLineModel.OnOrderLineIsDeleted += DeleteOrderLine;
        }
        public OrderModel(IPriceBook priceBook, IOrderManagementService orderService, OrderDto o)
        {
            _priceBook = priceBook;
            _orderManagementService = orderService;
            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto oldto in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, oldto);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
            OrderLineModel.OnOrderLineIsChanged += OnOrderLineChanged;
            OrderLineModel.OnOrderLineIsDeleted += DeleteOrderLine;
        }
        public int LineCount{get;set;}
        public void AddOrderLine(OrderLineModel orderLineModel)
        {
            //order_lines.Add(orderLineModel);

            List<IngredientDto> listedingr = new List<IngredientDto>();
            foreach (IngredientModel ingrm in orderLineModel.addedingredients)
            {
                IngredientDto ingredientDto = new IngredientDto
                {
                    Id = ingrm.Id

                };
                listedingr.Add(ingredientDto);
            }
            OrderLineDto oldto = new OrderLineDto
            {
                position_price = orderLineModel.Position_price,
                ordersId = (int)Id,
                custom = orderLineModel.Custom,
                weight = orderLineModel.Weight,
                pizzaId = orderLineModel.Pizza.Id,
                pizza_sizesId = orderLineModel.Pizza_sizesId,
                quantity = orderLineModel.Quantity,
                addedingredients = listedingr,
                Pizza = new PizzaDto
                {
                    Id = orderLineModel.Pizza.Id
                }
            };

            if (orderLineModel.Id == 0)
            {
                _orderService.CreateOrderLine(oldto);
                order_lines.Add(orderLineModel);

            }
            else
            {
                oldto.Id = orderLineModel.Id;
                _orderService.UpdateOrderLine(oldto);
                OrderLineModel linemodel = order_lines.Where(i =>i.Id==orderLineModel.Id).FirstOrDefault();
                //linemodel.Position_price=orderLineModel.Position_price;
                //linemodel.Weight = orderLineModel.Weight;
                //linemodel.Quantity = orderLineModel.Quantity;
                order_lines.Remove(linemodel);
                order_lines.Add(orderLineModel);
            }
            CalculateOrderPrice();
            CalculateOrderWeight();
            OrderDto newodto = new OrderDto
            {
                Id=Id,
                ordertime = null,
                address_del = address_del,
                delstatusId = delstatusId,
                final_price = final_price,
                weight = weight
            };
            _orderService.UpdateOrder(newodto);
            OrderDto o = _orderService.GetOrder((int)Id);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
            
        }

        public void OnOrderLineChanged(int id)
        {
            if (id == Id)
            {
                CalculateOrderPrice();
                CalculateOrderWeight();
                OnOrderIsChanged?.Invoke();
            }
        }

        public void CalculateOrderPrice()
        {
            final_price=order_lines.Select(ol => ol.Position_price).Sum();

        }

        public void CalculateOrderWeight()
        {
            weight = order_lines.Select(ol => ol.Weight).Sum();
        }

        public void DeleteOrderLine(int OrderId, int OrderLineId)
        {
            if (OrderId == Id)
            {
                _orderService.DeleteOrderLine(OrderLineId);

                OrderLineModel deletingmodel = order_lines.Where(i => i.Id == OrderLineId).FirstOrDefault();
                order_lines.Remove(deletingmodel);
                CalculateOrderPrice();
                CalculateOrderWeight();
                OrderDto newodto = new OrderDto
                {
                    Id = Id,
                    ordertime = null,
                    address_del = address_del,
                    delstatusId = delstatusId,
                    final_price = final_price,
                    weight = weight
                };
                _orderService.UpdateOrder(newodto);
                OrderDto o = _orderService.GetOrder((int)Id);

                Id = o.Id;
                clientId = o.clientId;
                courierId = o.courierId;
                managerId = o.managerId;
                final_price = o.final_price;
                address_del = o.address_del;
                weight = o.weight;
                ordertime = o.ordertime;
                deliverytime = o.deliverytime;
                delstatusId = o.delstatusId;
                comment = o.comment;
                order_lines = new List<OrderLineModel>();
                foreach (OrderLineDto old in o.order_lines)
                {
                    OrderLineModel olm = new OrderLineModel(_priceBook, old);
                    order_lines.Add(olm);
                }
                LineCount = order_lines.Count;
                
            }
            

        }

        public void CancelYourself()
        {
            OrderDto newodto = new OrderDto();


            newodto.Id = Id;
            newodto.address_del = address_del;
            newodto.delstatusId = (int)DeliveryStatus.Canceled;
            newodto.final_price = final_price;
            newodto.weight = weight;
            
            _orderService.UpdateOrder(newodto);
            OrderDto o = _orderService.GetOrder(newodto);

            Id = o.Id;
            clientId = o.clientId;
            courierId = o.courierId;
            managerId = o.managerId;
            final_price = o.final_price;
            address_del = o.address_del;
            weight = o.weight;
            ordertime = o.ordertime;
            deliverytime = o.deliverytime;
            delstatusId = o.delstatusId;
            comment = o.comment;
            order_lines = new List<OrderLineModel>();
            foreach (OrderLineDto old in o.order_lines)
            {
                OrderLineModel olm = new OrderLineModel(_priceBook, old);
                order_lines.Add(olm);
            }
            LineCount = order_lines.Count;
        }

        public bool CheckSelf()
        {
            return (CheckOrder(_orderService.GetOrder((int)Id)));
            //    return SubmitOrderResult.Success;
            //return SubmitOrderResult.FailedOrderComponent;
        }

        public bool CheckOrder(OrderDto orderDto)
        {
            _priceBook.KnowPriceAndWeight();
            //_priceBook.KnowBaseWeight();
            decimal price=0, weight=0;
            bool flag = true;
            
            foreach (OrderLineDto _orderLineDto in orderDto.order_lines)
            {
                OrderLineModel olm = order_lines.Where(i => i.Id == _orderLineDto.Id).FirstOrDefault();
                
                if (!olm.UpdateSelf(_orderLineDto))
                { 
                    flag = false;
                }
                
                price += olm.Position_price ;
                weight += olm.Weight;
            }
            final_price= price;
            this.weight = weight;
            return flag;
        }
        public SubmitOrderResult SubmitOrder(string AddressDel)
        {
            address_del = AddressDel;
            //if (final_price == (decimal)0.00)
            //    return SubmitOrderResult.FailedOrderIsEmpty;
            //if (address_del == null || address_del == "")
            //    return SubmitOrderResult.FailedAddressIsEmpty;
            if (CheckOrder(_orderService.GetOrder((int)Id)))
            {
                delstatusId = (int)DeliveryStatus.IsBeingFormed;
                ordertime = DateTime.UtcNow;

                OrderDto odto = new OrderDto
                {
                    Id = Id,
                    address_del = address_del,
                    weight = weight,
                    ordertime = ordertime,
                    delstatusId = delstatusId,
                    final_price = final_price
                };
                if (_orderService.UpdateOrder(odto))
                    return SubmitOrderResult.Success;
                return SubmitOrderResult.Failed;
            }
            return SubmitOrderResult.FailedOrderComponent;
        }
    }
}
