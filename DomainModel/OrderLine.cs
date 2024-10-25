using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrdersId { get; set; }

    public int PizzaId { get; set; }

    public int Quantity { get; set; }

    public bool Custom { get; set; }

    public decimal PositionPrice { get; set; }

    public int PizzaSizesId { get; set; }

    public decimal Weight { get; set; }

    public virtual Order Orders { get; set; } = null!;

    public virtual Pizza Pizza { get; set; } = null!;

    public virtual PizzaSize PizzaSizes { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
