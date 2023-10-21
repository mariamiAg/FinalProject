using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Warehouse
{
    public int Id { get; set; }

    public DateTime OperationDate { get; set; }

    public string DocNumber { get; set; } = null!;

    public int ProductId { get; set; }

    public int SupplierId { get; set; }

    public int UnitId { get; set; }

    public int Quantity { get; set; }

    public string? ExpiryDate { get; set; }

    public int UnitPrice { get; set; }

    public int RealizationPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
