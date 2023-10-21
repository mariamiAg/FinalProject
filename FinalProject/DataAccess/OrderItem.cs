using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int UnitePrice { get; set; }

    public int Quantity { get; set; }

    public bool IsDiscounted { get; set; }

    public int? DiscountPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
