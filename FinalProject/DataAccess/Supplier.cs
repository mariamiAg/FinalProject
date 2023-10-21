using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Supplier
{
    public int Id { get; set; }

    public string CompanyCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string ContacFullName { get; set; } = null!;

    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string Phone { get; set; } = null!;

    public string? Fax { get; set; }

    public string? WebSite { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
