using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class CustomersPhoneNumber
{
    public int Id { get; set; }

    public int PhoneTypeId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public string? IsMain { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual PhoneType PhoneType { get; set; } = null!;
}
