using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class RelationshipType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CustomerRelationship> CustomerRelationships { get; set; } = new List<CustomerRelationship>();
}
