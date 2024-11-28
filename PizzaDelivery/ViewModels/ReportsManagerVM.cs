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
        public ReportsManagerVM()
        {

        }
    }
}
