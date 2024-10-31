using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CourierModel : UserModel
    {
        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
