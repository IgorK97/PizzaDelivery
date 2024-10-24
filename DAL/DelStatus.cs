using System;
using System.Collections.Generic;

namespace DAL;

public partial class DelStatus
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
