//using DomainModel;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IReportService
    {
        List<OrdersByMonthDto> ExecuteSP(int month, int year);

        List<ReportData> ReportPizzas(int? ingredientId);
    }
}
