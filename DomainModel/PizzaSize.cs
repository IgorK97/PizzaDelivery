using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class PizzaSize
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Weight { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
