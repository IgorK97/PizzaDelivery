using DomainModel;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderService
    {
        int GetCurrentOrder(int ClientId);


        public UserDTO? GetCurrentUser(string login, string password);

        bool MakeOrder(int ClientId);


        bool CancelOrder(int odId);

        bool SubmitOrder(int odId, string addressdel);

        (decimal price, decimal weight) UpdateOrder(int odI);

        bool UpdateUser(UserDTO _user);
        List<OrderDto> GetAllOrders(int ClientId);

        List<ManagerDto> GetAllManagers();

        List<CouriersDto> GetAllCouriers();
    }
}
