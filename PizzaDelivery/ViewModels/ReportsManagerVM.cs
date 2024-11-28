using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class ReportsManagerVM : ViewModelBase
    {
        private ICommand reportCommand;
        public ICommand ReportCommand
        {
            get
            {
                return reportCommand;
            }
        }
        public string Im
        {
            get
            {
                return "/ImagesForProject/pizzaicon.png";
            }
        }
        public ISeries[] Series { get; set; }
        = new ISeries[]
        {
            new PieSeries<double>{Values = new double[] {2 } },
            new PieSeries<double>{Values = new double[] {1 } },
            new PieSeries<double>{Values = new double[] {4 } },
            new PieSeries<double>{Values = new double[] {5 } }
        };
        public ReportsManagerVM()
        {

        }
    }
}
