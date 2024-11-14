using BLL.Services;
using DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public delegate void OrderLineIsChanged(int Id);
    public delegate void OrderLineIsDeleted(int Id, int id);


    public class OrderLineModel
    {
        private readonly IPriceBook _priceBook;
        public static event OrderLineIsChanged OnOrderLineIsChanged;
        public static event OrderLineIsDeleted OnOrderLineIsDeleted;

        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
        public bool Custom { get; set; }
        public decimal Position_price { get; set; }
        public int Pizza_sizesId { get; set; }
        public decimal Weight { get; set; }

        public PizzaModel Pizza;
        
        public List<IngredientModel> addedingredients { get; set; }

        public OrderLineModel(IPriceBook pb, int id)
        {
            _priceBook = pb;
            OrdersId = id;
        }

        public void DeleteYourself()
        {
            OnOrderLineIsDeleted?.Invoke(OrdersId, Id);
        }

        public OrderLineModel(IPriceBook pb, OrderLineDto oldto)
        {
            _priceBook = pb;
            Id = oldto.Id;
            OrdersId = oldto.ordersId;
            PizzaId = oldto.pizzaId;
            Quantity = oldto.quantity;
            Custom= oldto.custom;
            Position_price = oldto.position_price;
            Weight = oldto.weight;
            Pizza_sizesId = oldto.pizza_sizesId;
            Pizza = new PizzaModel(oldto.Pizza);
            addedingredients = new List<IngredientModel>();
            foreach(IngredientDto ingrdto in oldto.addedingredients)
            {
                IngredientModel ingredientModel = new IngredientModel(ingrdto);
                addedingredients.Add(ingredientModel);
            }
        }

        public OrderLineModel(IPriceBook priceBook, IOrderLineService ols, PizzaModel pizza, int id)
        {
            _priceBook = priceBook;
            Pizza = pizza;
            Quantity = 1;
            PizzaId = pizza.Id;
            Custom = false;
            OrdersId = id;
            //decimal price, weight;
            //(price, weight) = ols.GetBasePriceAndWeight(0);
            Position_price = (priceBook.GetBasePrice(1) + Pizza.CalculatePrice(1))*Quantity;
            Weight = (priceBook.GetBaseWeight(1) + Pizza.CalculateWeight(1))*Quantity;
            Pizza_sizesId = 1;
            addedingredients = new List<IngredientModel>();
        }

        public (decimal price, decimal weight) CalculateExtraingredients()
        {
            decimal price, weight;
            if (Pizza_sizesId == 1)
            {
                price = addedingredients.Select(i => i.small*i.price_per_gram).Sum();
                weight = addedingredients.Select(i => i.small).Sum();
                return (price, weight);
            }
            if (Pizza_sizesId == 2)
            {
                price = addedingredients.Select(i => i.medium * i.price_per_gram).Sum();
                weight = addedingredients.Select(i => i.medium).Sum();
                return (price, weight);
            }
            price = addedingredients.Select(i => i.big * i.price_per_gram).Sum();
            weight = addedingredients.Select(i => i.big).Sum();
            return (price, weight);
        }
        public (decimal price, decimal weight) CalculateLine()
        {
            decimal p, w;
            (p, w) = CalculateExtraingredients();
            Position_price = (_priceBook.GetBasePrice(Pizza_sizesId) + Pizza.CalculatePrice(Pizza_sizesId) + p)*Quantity;
            Weight = (_priceBook.GetBaseWeight(Pizza_sizesId) + Pizza.CalculateWeight(Pizza_sizesId) + w) * Quantity;
            return (Position_price, Weight);
        }
        public (decimal price, decimal weight) ChangeSize(int s)
        {
            Pizza_sizesId = s;
            decimal p, w;
            (p, w) = CalculateExtraingredients();
            Position_price = (_priceBook.GetBasePrice(s) + Pizza.CalculatePrice(s) + p) * Quantity;
            Weight = (_priceBook.GetBaseWeight(s) + Pizza.CalculateWeight(s) + w) * Quantity;
            OnOrderLineIsChanged?.Invoke(OrdersId);
            return (Position_price, Weight);
        }
        public (decimal price, decimal weight) AddIngredient(IngredientModel newIngredient)
        {
            addedingredients.Add(newIngredient);
            Custom = true;
            (decimal price, decimal weight) = CalculateLine();
            OnOrderLineIsChanged?.Invoke(OrdersId);
            return (price, weight);
        }

        public (decimal price, decimal weight) DeleteIngredient(IngredientModel oldIngredient)
        {
            IngredientModel im = addedingredients.Find(i => i.Id == oldIngredient.Id);
            if (im != null)
                addedingredients.Remove(im);
            if (addedingredients.Count == 0)
                Custom = false;
            (decimal price, decimal weight) = CalculateLine();
            OnOrderLineIsChanged?.Invoke(OrdersId);
            return (price, weight);
        }
    }
}
