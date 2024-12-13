using DTO;
using Interfaces.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Interfaces.Services
{
    public interface IAccountStore
    {
        int Id { get; set; }
        UserDTO CurrentAccount { get; set; }
        
        event Action StateChanged;

        bool IsClient { get; }
        bool IsCourier { get; }
        bool IsManager { get; }
    }
}
