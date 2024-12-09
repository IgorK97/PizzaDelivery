using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Courier
{
    //public int Id { get; set; }
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
