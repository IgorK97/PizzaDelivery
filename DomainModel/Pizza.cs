using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Pizza
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public string Description { get; set; } = null!;

    public byte[]? Pizzaimage { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
