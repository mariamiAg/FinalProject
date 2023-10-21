using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Unit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
