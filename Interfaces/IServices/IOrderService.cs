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
        bool UpdateOrder(OrderDto odto);
        OrderDto GetOrder(int Id);
        OrderDto GetOrder(OrderDto o);
        bool MakeOrder(int ClientId);

        int GetCurrentOrder(int ClientId);
        //bool CancelOrder(int odId);

        //bool SubmitOrder(int odId, string addressdel);

        //(decimal price, decimal weight) UpdateOrder(int odI);

        //bool UpdateUser(UserDTO _user);
        List<OrderDto> GetAllOrders(int ClientId);
        void CreateOrderLine(OrderLineDto p);

        void UpdateOrderLine(OrderLineDto p);
        void UpdateCount(OrderLineDto p);
        void DeleteOrderLine(int id);

        //List<ManagerDto> GetAllManagers();

        //List<CouriersDto> GetAllCouriers();
    }
}
