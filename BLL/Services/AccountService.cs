using DomainModel;
using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService :IAccountService
    {
        private IDbRepos db;
        //PizzaDeliveryContext db;
        public AccountService(IDbRepos repos)
        {
            db = repos;
            //db = new PizzaDeliveryContext();
        }
        public UserDTO? GetByLogin(string login)
        {
            var res = db.Users.GetList().Where(i => i.Login == login).FirstOrDefault();
            if (res != null)
            {
                var res_client = db.Clients.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                if (res_client != null)
                {
                    return new ClientDTO
                    {
                        Id = res_client.Id,
                        Email = res_client.Email,
                        Phone = res_client.Phone,
                        Password = res.Password,
                        Login = res.Login,
                        FirstName = res.FirstName,
                        AddressDel = res_client.AddressDel,
                        LastName = res.LastName,
                        Surname = res.Surname
                    };
                }
                var res_courier = db.Couriers.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                if (res_courier != null)
                {
                    return new CouriersDto
                    {
                        Id = res_courier.Id,
                        Email = res_courier.Email,
                        Phone = res_courier.Phone,
                        Password = res.Password,
                        Login = res.Login,
                        FirstName = res.FirstName,
                        LastName = res.LastName,
                        Surname = res.Surname
                    };
                }
                var res_manager = db.Managers.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                if (res_manager != null)
                {
                    return new ManagerDto
                    {
                        Id = res_manager.Id,
                        Email = res_manager.Email,
                        Phone = res_manager.Phone,
                        Password = res.Password,
                        Login = res.Login,
                        FirstName = res.FirstName,
                        LastName = res.LastName,
                        Surname = res.Surname
                    };
                }


            }
            return null;
        }

        public UserDTO? GetByPhone(string phone)
        {
            var res = db.Clients.GetList().Where(i => i.Phone == phone).FirstOrDefault();
            if (res != null)
            {
                var res_cl = db.Users.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                return new ClientDTO
                {
                    Id = res_cl.Id,
                    Email = res.Email,
                    Phone = res.Phone,
                    Password = res_cl.Password,
                    Login = res_cl.Login,
                    FirstName = res_cl.FirstName,
                    AddressDel = res.AddressDel,
                    LastName = res_cl.LastName,
                    Surname = res_cl.Surname
                };

            }
            var res1 = db.Couriers.GetList().Where(i => i.Phone == phone).FirstOrDefault();
            if (res1 != null)
            {
                var res_cl = db.Users.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                return new CouriersDto
                {
                    Id = res_cl.Id,
                    Email = res1.Email,
                    Phone = res1.Phone,
                    Password = res_cl.Password,
                    Login = res_cl.Login,
                    FirstName = res_cl.FirstName,
                    LastName = res_cl.LastName,
                    Surname = res_cl.Surname
                };

            }
            var res2 = db.Managers.GetList().Where(i => i.Phone == phone).FirstOrDefault();
            if (res2 != null)
            {
                var res_cl = db.Users.GetList().Where(i => i.Id == res.Id).FirstOrDefault();
                return new ManagerDto
                {
                    Id = res_cl.Id,
                    Email = res2.Email,
                    Phone = res2.Phone,
                    Password = res_cl.Password,
                    Login = res_cl.Login,
                    FirstName = res_cl.FirstName,
                    LastName = res_cl.LastName,
                    Surname = res_cl.Surname
                };

            }
            return null;
        }

        public bool Create(UserDTO userDTO)
        {
            User _user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Surname = userDTO.Surname,
                Login = userDTO.Login,
                Password = userDTO.Password

            };
            db.Users.Create(_user);
            var newu = db.Users.GetList().Where(i => i.Login == userDTO.Login).First();
            if (newu != null)
            {
                ClientDTO cl = (ClientDTO)userDTO;
                Client _client = new Client
                {
                    AddressDel = cl.AddressDel,
                    Phone = cl.Phone,
                    Email = cl.Email,
                    Id = newu.Id
                };
                db.Clients.Create(_client);
                return db.Save() != 0;
            }
            return false;
        }
    }
}
