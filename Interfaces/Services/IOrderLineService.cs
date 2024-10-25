using DomainModel;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderLineService
    {
        List<OrderLineDto> GetAllOrderLines(int? OrderId);


        OrderLineDto GetOrderLine(int Id);

        void CreateOrderLine(OrderLineDto p);

        void UpdateOrderLine(OrderLineDto p);

        void DeleteOrderLine(int id);


        bool Save();

        List<PizzaDto> GetPizzas();

        List<PizzaSizesDto> GetPizzaSizes();

        List<DelStatusDto> GetDelStatuses();

        BindingList<IngredientShortDto> GetIngredients(int? ps);

        BindingList<IngredientShortDto> GetConcreteIngredients(int ps, int ol_id);

        (decimal price, decimal weight) GetBasePriceAndWeight(int ps);

        (decimal price, decimal weight) GetConcretePriceAndWeight(int p_id, int ps, decimal count);

        (decimal price, decimal weight) PriceAndWeightCalculation(BindingList<IngredientShortDto> allingredients, int  ps, int p_id, decimal count);

        void ChangeAdditionalItems(BindingList<IngredientShortDto> allingredients, int add_id);
        
    }
}
