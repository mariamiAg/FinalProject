using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Product
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
