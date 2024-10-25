using BLL.Models;
using Interfaces.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4POWinForms.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            
                Bind<IOrderService>().To<OrderService>();
            Bind<IReportService>().To<ReportService>();
            Bind<IOrderLineService>().To<OrderLinesService>();
        }
    }
}
