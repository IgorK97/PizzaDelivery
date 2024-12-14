using DomainModel;
using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using Interfaces.Services.AuthenticationServices;
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
            try
            {
                var res = db.Users.GetList().Where(i => i.Login == login).FirstOrDefault();
                if (res != null)
                {
                    //var res_client = db.Clients.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                    if (res.Client != null)
                    {
                        return new ClientDTO
                        {
                            Id = res.Id,
                            Email = res.Client.Email,
                            Phone = res.Client.Phone,
                            Password = res.Password,
                            Login = res.Login,
                            FirstName = res.FirstName,
                            AddressDel = res.Client.AddressDel,
                            LastName = res.LastName,
                            Surname = res.Surname
                        };
                    }

                    //var res_manager = db.Managers.GetList().Where(i => i.Id == res.Id).FirstOrDefault();

                    if (res.Courier != null)
                    {
                        return new CouriersDto
                        {
                            Id = res.Id,
                            Email = res.Courier.Email,
                            Phone = res.Courier.Phone,
                            Password = res.Password,
                            Login = res.Login,
                            FirstName = res.FirstName,
                            LastName = res.LastName,
                            Surname = res.Surname
                        };
                    }

                    if (res.Manager != null)
                    {
                        return new ManagerDto
                        {
                            Id = res.Id,
                            Email = res.Manager.Email,
                            Phone = res.Manager.Phone,
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
            catch (Exception)
            {
                return null;
            }
        }

        public UserDTO? GetByPhone(string phone)
        {
            try
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
                    var res_cl = db.Users.GetList().Where(i => i.Id == res1.Id).FirstOrDefault();

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
                    var res_cl = db.Users.GetList().Where(i => i.Id == res2.Id).FirstOrDefault();
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
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool Update(UserDTO userDTO)
        {

            try
            {
                User user = db.Users.GetItem(userDTO.Id);
                if (user != null)
                {

                    user.FirstName = userDTO.FirstName;
                    user.LastName = userDTO.LastName;
                    user.Surname = userDTO.Surname;
                    user.Login = userDTO.Login;
                    user.Password = userDTO.Password;

                    if (user.Client != null)
                    {
                        user.Client.Phone = ((ClientDTO)userDTO).Phone;
                        user.Client.Email = ((ClientDTO)userDTO).Email;
                        user.Client.AddressDel = ((ClientDTO)userDTO).AddressDel;
                        db.Save();
                        return true;
                    }
                    if (user.Courier != null)
                    {
                        user.Courier.Phone = ((CouriersDto)userDTO).Phone;
                        user.Courier.Email = ((CouriersDto)userDTO).Email;
                        db.Save();
                        return true;
                    }
                    if (user.Manager != null)
                    {
                        user.Manager.Phone = ((ManagerDto)userDTO).Phone;
                        user.Manager.Email = ((ManagerDto)userDTO).Email;
                        db.Save();
                        return true;
                    }

                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public bool Create(UserDTO userDTO)
        {
            try
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
