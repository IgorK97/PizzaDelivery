using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Order
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int? CourierId { get; set; }

    public decimal FinalPrice { get; set; }

    public string AddressDel { get; set; } = null!;

    public decimal Weight { get; set; }

    public DateTime? Ordertime { get; set; }

    public DateTime? Deliverytime { get; set; }

    public int DelstatusId { get; set; }

    public string? Comment { get; set; }

    public int? ManagersId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Courier? Courier { get; set; }

    public virtual DelStatus Delstatus { get; set; } = null!;

    public virtual Manager? Managers { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
