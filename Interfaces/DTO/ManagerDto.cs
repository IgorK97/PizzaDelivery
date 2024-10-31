using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ManagerDto : UserDTO
    {
        public ManagerDto()
        {

        }
        
        public string Phone { get; set; }
        public string? Email { get; set; }
        public ManagerDto(Manager m, User u)
        {
            Id = m.Id;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Surname = u.Surname;
            Login = u.Login;
            Phone = m.Phone;
            Email = m.Email;
            Password = u.Password;
        }
    }
}
