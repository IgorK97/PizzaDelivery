using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositoryPostgreSQL : IReportsRepository
    {
        private PizzaDeliveryNewGenContext db;
        
        public ReportRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }
        public List<OrdersByMonth> ExecuteSP(int month, int year, int ClientId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("month", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter param2 = new NpgsqlParameter("year", NpgsqlTypes.NpgsqlDbType.Integer);
            param1.Value = month;
            param2.Value = year;

            //var result = dbContext.Database.SqlQuery<ParResult>("select * from _GetOrdersByMonthYear(@month, @year)", new object[] { param1, param2 }).ToList();
            //var result = dbContext.Database.SqlQuery<int>($"select * from _GetOrdersByMonthYear(@month={param1}, @year={param2})").ToList();

            var result = db.Orders.FromSql($"select * from getordersbymonthandyearnew({param1}, {param2})").ToList();

            var data = result.Where(i => i.ClientId == ClientId && i.CourierId != null).Select(j =>
            new OrdersByMonth
            {
                order_id = j.Id,
                courier_id = db.Users.Where(c =>
            c.Id == j.CourierId).Select(c => new
            {
                fname = c.FirstName + " " + c.LastName + " " + c.Surname
            }).FirstOrDefault().fname,
                Date = j.Ordertime
            }).OrderByDescending(c => c.Date).ToList();

            return data;
        }
        public List<ReportData> PizzaWithIngredients(int? ingredientId)
        {
            if (ingredientId != null)
            {
                var request = db.Pizzas.Where(p => p.Ingredients.Any(i => i.Id == ingredientId))
                .Select(p => new ReportData
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description

                }).ToList();
                return request;
            }
            var request1 = db.Pizzas.Select(p => new ReportData
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description

            }).ToList();
            return request1;
        }

        //выполнить ХП
        

        
    }
}
