using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
