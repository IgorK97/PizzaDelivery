using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Surname { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? AddressDel { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public UserModel()
        {

        }

        public void MakeLogin()
        {

        }

    }
}
