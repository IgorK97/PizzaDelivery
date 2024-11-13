using DTO;
using Interfaces.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.State.Accounts
{
    public interface IAccountStore
    {
        int Id { get; set; }
        UserDTO CurrentAccount { get; set; }
        
        event Action StateChanged;
    }
}
