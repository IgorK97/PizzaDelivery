using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<Pizza> Pizzas { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Order> Orders { get; }
        IRepository<Client> Clients { get; }
        //IRepository<User> Users { get; }
        IRepository<Courier> Couriers { get; }
        IRepository<Manager> Managers { get; }
        IRepository<DelStatus> DelStatuses { get; }
        IRepository<OrderLine> OrderLines { get; }
        IRepository<PizzaSize> PizzaSizes { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
