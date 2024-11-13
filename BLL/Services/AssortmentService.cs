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
    public class AssortmentService :IAssortmentService
    {
        private IDbRepos dbr;
        //private PizzaDeliveryContext db;
        public AssortmentService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        public IEnumerable<PizzaDto> GetPizzas()
        {
            return dbr.Pizzas.GetList().Select(i => new PizzaDto(i));
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            var res = dbr.Ingredients.GetList().Select(i => new IngredientDto
            {
                Id = i.Id,
                C_name = i.Name,
                price_per_gram = i.PricePerGram,
                small = i.Small,
                medium = i.Medium,
                big = i.Big,
                active = i.Active,
                ingrimage = i.Ingrimage
            });
            //var blres = new List<IngredientDto>(res);
            return res;
        }
    }
}
