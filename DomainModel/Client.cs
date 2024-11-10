using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Client : DomainObject
{
    //public int Id { get; set; }

    public string? AddressDel { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
