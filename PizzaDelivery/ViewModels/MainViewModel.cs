using BLL.Models;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(UserModel _user)
        {
            CurrentViewModel = new AuthorizationVM(_user);
            //CurrentViewModel = new PizzaSelectionVM();

        }
    }
}
