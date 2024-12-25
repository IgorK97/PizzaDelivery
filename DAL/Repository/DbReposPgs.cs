using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposPgs : IDbRepos
    {
        string connection;
        private PizzaDeliveryNewGenContext db;
        private PizzaRepositoryPostgreSQL pizzaRepository;
        private OrderRepositoryPostgreSQL orderRepository;
        private IngredientRepositoryPostgreSQL ingredientRepository;
        private ClientRepositoryPostgreSQL clientRepository;
        private DelStatusRepositoryPostgreSQL delstatusRepository;
        private CourierRepositoryPostgreSQL courierRepository;
        private ManagerRepositoryPostgreSQL managerRepository;
        private OrderLineRepositoryPostgreSQL orderLineRepository;
        private PizzaSizeRepositoryPostgreSQL pizzaSizeRepository;
        private ReportRepositoryPostgreSQL reportRepository;
        private UserRepositoryPostgreSQL userRepository;

        public DbReposPgs(string connection)
        {
            db = new PizzaDeliveryNewGenContext(connection);
            this.connection = connection;
        }
        public void ResetContext()
        {
            db.Dispose(); 
            db = new PizzaDeliveryNewGenContext(connection); 
            pizzaRepository = new PizzaRepositoryPostgreSQL(db);
            ingredientRepository = new IngredientRepositoryPostgreSQL(db);
            orderLineRepository = new OrderLineRepositoryPostgreSQL(db);
            orderRepository = new OrderRepositoryPostgreSQL(db);
            clientRepository = new ClientRepositoryPostgreSQL(db);
            delstatusRepository = new DelStatusRepositoryPostgreSQL(db);
            courierRepository = new CourierRepositoryPostgreSQL(db);
            managerRepository = new ManagerRepositoryPostgreSQL(db);
            pizzaSizeRepository = new PizzaSizeRepositoryPostgreSQL(db);
            reportRepository=new ReportRepositoryPostgreSQL(db);
            userRepository=new UserRepositoryPostgreSQL(db);

        }

        public IRepository<Pizza> Pizzas
        {
            get
            {
                if (pizzaRepository == null)
                    pizzaRepository = new PizzaRepositoryPostgreSQL(db);
                return pizzaRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositoryPostgreSQL(db);
                return userRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepositoryPostgreSQL(db);
                return orderRepository;
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepositoryPostgreSQL(db);
                return ingredientRepository;
            }
        }

        public IRepository<Client> Clients { get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepositoryPostgreSQL(db);
                return clientRepository;
            }
        }
        //IRepository<User> Users { get { 
        //    if(userRepo)
        //    } }
        public IRepository<Courier> Couriers { get {
                if (courierRepository == null)
                    courierRepository = new CourierRepositoryPostgreSQL(db);
                return courierRepository;
            } }
        public IRepository<Manager> Managers { get {
                if (managerRepository == null)
                    managerRepository = new ManagerRepositoryPostgreSQL(db);
                return managerRepository;
            } }
        public IRepository<DelStatus> DelStatuses{ get {
                if (delstatusRepository == null)
                    delstatusRepository = new DelStatusRepositoryPostgreSQL(db);
                return delstatusRepository;
            } }
        public IRepository<OrderLine> OrderLines { get {
                if (orderLineRepository == null)
                    orderLineRepository = new OrderLineRepositoryPostgreSQL(db);
                return orderLineRepository;
            } }
        public IRepository<PizzaSize> PizzaSizes { get {
                if (pizzaSizeRepository == null)
                    pizzaSizeRepository = new PizzaSizeRepositoryPostgreSQL(db);
                return pizzaSizeRepository;
            } }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepositoryPostgreSQL(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            //try
            //{
                return db.SaveChanges();

            //}
            //catch(Exception){
            //    return 0;
            //}
        }
    }
}
