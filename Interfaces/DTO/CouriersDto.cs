using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CouriersDto
    {
        public CouriersDto()
        {
        }

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string? surname { get; set; }
        public string login { get; set; }
        public string C_password { get; set; }
        public string phone { get; set; }
        public string? email { get; set; }
        public CouriersDto(Courier c, User u)
        {
            id = c.Id;
            first_name = u.FirstName;
            last_name = u.LastName;
            surname = u.Surname;
            login = u.Login;
            phone = c.Phone;
            email = c.Email;
            C_password = u.Password;
        }
    }
}
