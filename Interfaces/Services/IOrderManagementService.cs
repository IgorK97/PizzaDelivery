using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderManagementService
    {
        bool UpdateOrder(OrderDto odto);

        OrderDto GetOrder(OrderDto o);

        List<OrderDto> GetAllOrders();

        
    }
}
