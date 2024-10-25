using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DelStatusDto
    {
        public DelStatusDto()
        {

        }
        public int Id { get; set; }

        public string description { get; set; }
        public DelStatusDto(DelStatus ds)
        {
            Id = ds.Id;
            description = ds.Description;
        }
    }
}
