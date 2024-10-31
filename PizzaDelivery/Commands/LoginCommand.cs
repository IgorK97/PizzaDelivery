using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly UserModel _user;
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        public LoginCommand(UserModel user)
        {
            _user = user;
        }
    }
}
