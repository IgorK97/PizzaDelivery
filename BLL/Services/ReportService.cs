using Npgsql;
using DAL;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Interfaces.Repository;


namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;
        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<OrdersByMonthDto> ExecuteSP(int month, int year)
        {

            return db.Reports.ExecuteSP(month, year).Select(i => new OrdersByMonthDto
            {
                pizzaId = i.pizza_id,
                pizzaName = i.pizza_name,
                quantity = i.total_quantity,
                cost = i.total_cost
            }).ToList();


        }


        public List<ReportData> ReportPizzas(int? ingredientId)
        {

            var request = db.Reports.PizzaWithIngredients(ingredientId).Select(i =>
            new ReportData
            {
                Id = i.Id,
                Description = i.Description,
                Name = i.Name,
            })
            .ToList();
            return request;
        }
    }
}
