using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal PricePerGram { get; set; }

    public decimal Small { get; set; }

    public decimal Medium { get; set; }

    public decimal Big { get; set; }

    public bool Active { get; set; }

    public byte[]? Ingrimage { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
}
