using DomainModel;
using DTO;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static BLL.Services.ReportService;
using Interfaces.Services;
using Interfaces.Repository;

namespace BLL.Models
{
    public class OrderLinesService : IOrderLineService
    {
        private IDbRepos dbr;
        //private PizzaDeliveryContext db;
        public OrderLinesService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }

        public enum PizzaSizeEnum
        {
            Small = 1,
            Medium = 2,
            Big = 3
        };

        public List<OrderLineDto> GetAllOrderLines(int? OrderId)
        {
            return dbr.OrderLines.GetList().Where(i => i.OrdersId == OrderId).Select(i => new OrderLineDto(i)).ToList();
        }


        public OrderLineDto GetOrderLine(int Id)
        {
            return new OrderLineDto(dbr.OrderLines.GetItem(Id));
        }

        public void CreateOrderLine(OrderLineDto p)
        {
            List<Ingredient> addedingredients = new List<Ingredient>();
            foreach(var pId in p.addedingredientsId)
            {
                Ingredient ingr = dbr.Ingredients.GetItem(pId);
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
                Ingredients=addedingredients
            });
            Save();
            //db.order_lines.Attach(p);
        }

        public void UpdateOrderLine(OrderLineDto p)
        {
            List<Ingredient> addedingredients = new List<Ingredient>();
            foreach (var pId in p.addedingredientsId)
            {
                Ingredient ingr = dbr.Ingredients.GetItem(pId);
                addedingredients.Add(ingr);
            }
            OrderLine ol = dbr.OrderLines.GetItem(p.Id);
            ol.Weight = p.weight;
            ol.Custom = p.custom;
            ol.PizzaId = p.pizzaId;
            ol.PositionPrice = p.position_price;
            ol.PizzaSizesId = p.pizza_sizesId;
            ol.Quantity = p.quantity;
            ol.OrdersId = p.ordersId;
            ol.Ingredients = addedingredients;
            Save();
        }

        public void DeleteOrderLine(int id)
        {
            //OrderLine p = dbr.OrderLines.GetItem(id);
            //if (p != null)
            //{
                dbr.OrderLines.Delete(id);
                Save();
            //}
        }


        public bool Save()
        {
            if (dbr.Save() > 0) return true;
            return false;
        }

        public List<PizzaDto> GetPizzas()
        {
            return dbr.Pizzas.GetList().Select(i => new PizzaDto(i)).ToList();
        }

        public List<PizzaSizesDto> GetPizzaSizes()
        {
            return dbr.PizzaSizes.GetList().Select(i => new PizzaSizesDto(i)).ToList();
        }

        public List<DelStatusDto> GetDelStatuses()
        {
            return dbr.DelStatuses.GetList().Select(i => new DelStatusDto(i)).ToList();
        }

        public BindingList<IngredientShortDto> GetIngredients(int? ps = null)
        {
            if (ps == null)
                ps = (int)PizzaSizeEnum.Small;
            var res = dbr.Ingredients.GetList().Select(i => new IngredientShortDto
            {
                Id = i.Id,
                C_name = i.Name,
                price = ps == (int)PizzaSizeEnum.Small ? i.PricePerGram * i.Small : ps == (int)PizzaSizeEnum.Medium ?
                i.PricePerGram * i.Medium : i.PricePerGram * i.Big,
                weight = ps == (int)PizzaSizeEnum.Small ? i.Small : ps == (int)PizzaSizeEnum.Medium ?
                i.Medium : i.Big,
                active = false
            }).ToList();
            var blres = new BindingList<IngredientShortDto>(res);
            return blres;
        }

        public BindingList<IngredientShortDto> GetConcreteIngredients(int ps, int ol_id)
        {
            

            var res = dbr.Ingredients.GetList().Select(i => new IngredientShortDto
            {
                Id = i.Id,
                C_name = i.Name,
                price = ps == (int)PizzaSizeEnum.Small ? i.PricePerGram * i.Small : ps == (int)PizzaSizeEnum.Medium ?
                    i.PricePerGram * i.Medium : i.PricePerGram * i.Big,
                weight = ps == (int)PizzaSizeEnum.Small ? i.Small : ps == (int)PizzaSizeEnum.Medium ?
                    i.Medium : i.Big,
                active = i.OrderLines.Any(ol => ol.Id == ol_id)
            }).ToList();
            var blres = new BindingList<IngredientShortDto>(res);
            return blres;
        }

        public (decimal price, decimal weight) GetBasePriceAndWeight(int ps)
        {

            var res = dbr.PizzaSizes.GetList().Where(i => i.Id == ps).
                Select(i => new
                {
                    price = i.Price,
                    weight = i.Weight
                }).FirstOrDefault();
            return (res.price, res.weight);
        }

        public (decimal price, decimal weight) GetConcretePriceAndWeight(int p_id, int ps, decimal count)
        {
            //Pizza concrete_pizza = db.Pizzas.FirstOrDefault(p => p.Id == p_id);
            //if (concrete_pizza == null)
            //    throw new ArgumentException($"Pizza with ID {p_id} not found");
            decimal res_price = 0, res_weight = 0, base_price, base_weight;
            (base_price, base_weight) = GetBasePriceAndWeight(ps);
            if (ps == (int)PizzaSizeEnum.Small)
            {
                res_price = dbr.Ingredients.GetList().Where(p => p.Pizzas.Any(i => i.Id == p_id))
                .Select(p => new
                {
                    price = p.PricePerGram*p.Small

                }).Sum(i => i.price);
                res_weight = dbr.Ingredients.GetList().Where(p => p.Pizzas.Any(i => i.Id == p_id))
                    .Sum(i => i.Small);
            }
            else if (ps == (int)PizzaSizeEnum.Medium)
            {
                res_price = dbr.Ingredients.GetList().Where(p => p.Pizzas.Any(i => i.Id == p_id))
                .Select(p => new
                {
                    price = p.PricePerGram * p.Medium

                }).Sum(i => i.price);
                res_weight = dbr.Ingredients.GetList().Where(p => p.Pizzas.Any(i => i.Id == p_id))
                    .Sum(i => i.Medium);
            }
            else
            {
                res_price = dbr.Ingredients.GetList().Where(p => p.Pizzas.Any(i => i.Id == p_id))
                .Select(p => new
                {
                    price = p.PricePerGram * p.Big

                }).Sum(i => i.price);
                res_weight = dbr.Ingredients.GetList().Where(p => p.Pizzas.Any(i => i.Id == p_id))
                    .Sum(i => i.Big);
            }
            res_price += base_price;
            res_weight += base_weight;
            return (res_price * count, res_weight * count);

        }


        public (decimal price, decimal weight) PriceAndWeightCalculation(BindingList<IngredientShortDto> allingredients, int ps, int p_id, decimal count)
        {
            decimal price, weight, res_price, res_weight;
            (price, weight) = GetConcretePriceAndWeight(p_id, ps, count);

            res_price = allingredients.Where(i => i.active == true).Sum(i => i.price);
            res_price *= count;
            res_weight = allingredients.Where(i => i.active == true).Sum(i => i.weight);
            res_weight *= count;
            price += res_price;
            weight += res_weight;
            return (price, weight);
        }

        public void ChangeAdditionalItems(BindingList<IngredientShortDto> allingredients, int add_id)
        {
            var res = allingredients.Where(i => i.Id == add_id).First();
            res.active = !res.active;
        }
    }
}
