using Interfaces.Services;
using Ninject.Modules;
using PizzaDelivery.Util;
using PizzaDelivery.State.Navigators;
using PizzaDelivery.ViewModels;
using PizzaDelivery.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using BLL.Services;

namespace Lab4POWinForms.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            
            //Bind<INavigator>().To<Navigator>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IReportService>().To<ReportService>();
            Bind<IOrderLineService>().To<OrderLinesService>();
        }
    }
}
