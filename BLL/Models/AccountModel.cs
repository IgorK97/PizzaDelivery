using DTO;
using Exceptions;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AccountModel
    {
        private readonly IOrderService _ios;

        private UserModel _user;
        //public int Id { get; set; }

        //public string? FirstName { get; set; }

        //public string? LastName { get; set; }

        //public string? Surname { get; set; }

        //public string? Login { get; set; }

        //public string? Password { get; set; }

        //public string? AddressDel { get; set; }

        //public string? Phone { get; set; }

        //public string? Email { get; set; }

        public AccountModel(IOrderService Ios)
        {
            _ios = Ios;
        }

        public void MakeLogin(string login, string password)
        {
            
                UserDTO? user = _ios.GetCurrentUser(login, password);

                if (user is ClientDTO)
                {
                    ClientDTO user1 = (ClientDTO)user;
                    _user = new ClientModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Surname = user.Surname,
                        Login = login,
                        Password = password,
                        Email = user1.Email,
                        Phone = user1.Phone,
                        AddressDel = user1.AddressDel
                    };
                }
                else if (user is CouriersDto)
                {
                    CouriersDto user1 = (CouriersDto)user;
                    _user = new ClientModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Surname = user.Surname,
                        Login = login,
                        Password = password,
                        Email = user1.Email,
                        Phone = user1.Phone
                    };
                }
                else if (user is ManagerDto)
                {
                    ManagerDto user1 = (ManagerDto)user;
                    _user = new ClientModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Surname = user.Surname,
                        Login = login,
                        Password = password,
                        Email = user1.Email,
                        Phone = user1.Phone
                    };
                }
            
            
        }

    }
}
