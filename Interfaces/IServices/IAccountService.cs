using DTO;
using Interfaces.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IAccountService 
    {
        UserDTO? GetByLogin(string login);
        UserDTO? GetByPhone(string phone);


        bool Update(UserDTO user);
        bool Create(UserDTO _user);
    }
}
