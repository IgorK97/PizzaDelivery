using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exceptions
{
    public class UserNotFoundException :Exception
    {
        public string Login { get; set; }


        public UserNotFoundException(string? message, string login) : base(message)
        {
            Login = login;
        }

        public UserNotFoundException(string? message, Exception? innerException,
            string login) : base(message, innerException)
        {
            Login = login;
        }

        public UserNotFoundException(string login)
        {
            Login = login;
        }
    }
}
