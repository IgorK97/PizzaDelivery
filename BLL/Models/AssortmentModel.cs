using DomainModel;
using DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AssortmentModel
    {
        private List<PizzaDto> _pizzas;

        public IEnumerable<PizzaDto> Pizzas => _pizzas;

        private readonly IOrderLineService _orderLineService;

        public AssortmentModel(IOrderLineService orderLineService)
        {
            _orderLineService = orderLineService;
            _pizzas = orderLineService.GetPizzas();
        }

        //public LoadPizzas()
        //{

        //}
    }
}
