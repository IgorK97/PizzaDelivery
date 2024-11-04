using DTO;
using Exceptions;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel;

namespace BLL.Models
{
    public class AccountModel /*:INotifyPropertyChanged*/
    {
        private readonly IOrderService _ios;

        //private int _id;
        public int Id
        {
            get;
            //{
            //    return _id;
            //}
            set;
            //{
            //    _id = value;
            //}
        }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Surname { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? AddressDel { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? RepPassword { get; set; }

        public AccountModel(IOrderService Ios)
        {
            _ios = Ios;
        }

        public void SaveChanges()
        {
            UserDTO _user = new ClientDTO
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Surname = Surname,
                Login = Login,
                Password = Password,
                AddressDel = AddressDel,
                Phone = Phone,
                Email = Email,

            };
            _ios.UpdateUser(_user);
        }

        public void MakeReg()
        {
            ClientDTO userDTO = new ClientDTO
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Surname = Surname,
                Login = Login,
                Password = Password,
                AddressDel = AddressDel,
                Phone = Phone,
                Email = Email,
            };
            _ios.AddNewClient(userDTO);
        }
        public void MakeLogin(string login, string password)
        {
            
                UserDTO? user = _ios.GetCurrentUser(login, password);

                if (user is ClientDTO)
                {
                    ClientDTO user1 = (ClientDTO)user;
                    //_user = new ClientModel
                    //{
                    //    Id = user.Id,
                    //    FirstName = user.FirstName,
                    //    LastName = user.LastName,
                    //    Surname = user.Surname,
                    //    Login = login,
                    //    Password = password,
                    //    Email = user1.Email,
                    //    Phone = user1.Phone,
                    //    AddressDel = user1.AddressDel
                    //};
                Id=user1.Id;
                FirstName=user1.FirstName;
                LastName=user1.LastName;
                Surname=user1.Surname;
                Login=user1.Login;
                Password=user1.Password;
                Email=user1.Email;
                Phone=user1.Phone;
                AddressDel=user1.AddressDel;

                }
                else if (user is CouriersDto)
                {
                    CouriersDto user1 = (CouriersDto)user;
                //_user = new ClientModel
                //{
                //    Id = user.Id,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Surname = user.Surname,
                //    Login = login,
                //    Password = password,
                //    Email = user1.Email,
                //    Phone = user1.Phone
                //};
                Id = user1.Id;
                FirstName = user1.FirstName;
                LastName = user1.LastName;
                Surname = user1.Surname;
                Login = user1.Login;
                Password = user1.Password;
                Email = user1.Email;
                Phone = user1.Phone;
            }
                else if (user is ManagerDto)
                {
                    ManagerDto user1 = (ManagerDto)user;
                //_user = new ClientModel
                //{
                //    Id = user.Id,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Surname = user.Surname,
                //    Login = login,
                //    Password = password,
                //    Email = user1.Email,
                //    Phone = user1.Phone
                //};
                Id = user1.Id;
                FirstName = user1.FirstName;
                LastName = user1.LastName;
                Surname = user1.Surname;
                Login = user1.Login;
                Password = user1.Password;
                Email = user1.Email;
                Phone = user1.Phone;
            }
            
            
        }

    }
    //public event PropertyChangedEventHandler PropertyChanged;
    //protected void OnPropertyChanged(string propertyName)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}
}
