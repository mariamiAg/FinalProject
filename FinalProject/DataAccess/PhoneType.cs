using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class PhoneType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; } = new List<CustomersPhoneNumber>();
}
