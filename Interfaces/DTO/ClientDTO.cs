using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientDTO : UserDTO
    {
        public string? AddressDel { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
