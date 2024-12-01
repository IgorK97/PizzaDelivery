using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }

        public string C_name { get; set; }

        public bool active { get; set; }

        public string description { get; set; }
        public byte[]? pizzaimage { get; set; }

        public List<IngredientModel> listedingredients { get; set; }

        public PizzaModel(PizzaDto pizza)
        {
            Id = pizza.Id;
            C_name = pizza.C_name;
            active = pizza.active;
            description = pizza.description;
            pizzaimage = pizza.pizzaimage;
            listedingredients = new List<IngredientModel>();
            foreach(IngredientDto i in pizza.listedingredients)
            {
                IngredientModel im = new IngredientModel(i);
                listedingredients.Add(im);
            }
        }
        public bool UpdateSelf(PizzaDto pizza)
        {
            C_name = pizza.C_name;
            active = pizza.active;
            description = pizza.description;
            pizzaimage = pizza.pizzaimage;
            bool flag = active;
            foreach (IngredientDto i in pizza.listedingredients)
            {
                IngredientModel im = listedingredients.Where(i => i.Id == i.Id).FirstOrDefault();
                if (!im.UpdateSelf(i))
                    flag = false;

            }
            return flag;
        }

        public decimal CalculatePrice(int type)
        {
            //if (type == 1)
            //    return listedingredients.Select(i => new
            //    {
            //        price = i.small * i.price_per_gram
            //    }).Sum(i => i.price);
            //if(type==2)
            //    return listedingredients.Select(i => new
            //    {
            //        price = i.medium * i.price_per_gram
            //    }).Sum(i => i.price);
            //else
            //    return listedingredients.Select(i => new
            //    {
            //        price = i.big * i.price_per_gram
            //    }).Sum(i => i.price);
            return listedingredients.Select(i => new
            {
                price = i.GetPrice(type)
            }).Sum(i =>  i.price);
        }
        public decimal CalculateWeight(int type)
        {
            //if (type == 0)
            //    return listedingredients.Select(i => new
            //    {
            //        weight = i.small
            //    }).Sum(i => i.weight);
            //if (type == 1)
            //    return listedingredients.Select(i => new
            //    {
            //        weight=i.medium
            //    }).Sum(i => i.weight);
            //else
            //    return listedingredients.Select(i => new
            //    {
            //        weight=i.big
            //    }).Sum(i => i.weight);
            return listedingredients.Select(i => new
            {
                weight = i.GetWeight(type)
            }).Sum(i => i.weight);
        }
    }
}
