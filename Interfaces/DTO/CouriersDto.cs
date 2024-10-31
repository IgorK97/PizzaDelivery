using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CouriersDto : UserDTO
    {
        public CouriersDto()
        {
        }

        //public int Id { get; set; }
        //public string first_name { get; set; }
        //public string last_name { get; set; }
        //public string? surname { get; set; }
        //public string login { get; set; }
        //public string C_password { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public CouriersDto(User u, Courier c)
        {
            Id = c.Id;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Surname = u.Surname;
            Login = u.Login;
            Phone = c.Phone;
            Email = c.Email;
            Password = u.Password;
        }
    }
}
