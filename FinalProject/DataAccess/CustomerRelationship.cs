using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class CustomerRelationship
{
    public int Id { get; set; }

    public int RelationshipId { get; set; }

    public int StartCustomerId { get; set; }

    public int EndcustomerId { get; set; }

    public string? Comment { get; set; }

    public virtual Customer Endcustomer { get; set; } = null!;

    public virtual RelationshipType Relationship { get; set; } = null!;

    public virtual Customer StartCustomer { get; set; } = null!;
}
