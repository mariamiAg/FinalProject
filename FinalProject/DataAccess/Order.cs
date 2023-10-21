using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int CostumerId { get; set; }

    public int TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
