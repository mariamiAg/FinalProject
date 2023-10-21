using System;
using System.Collections.Generic;

namespace FinalProject.DataAccess;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int GenderId { get; set; }

    public string PersonalNumber { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string? Email { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<CustomerRelationship> CustomerRelationshipEndcustomers { get; set; } = new List<CustomerRelationship>();

    public virtual ICollection<CustomerRelationship> CustomerRelationshipStartCustomers { get; set; } = new List<CustomerRelationship>();

    public virtual ICollection<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; } = new List<CustomersPhoneNumber>();

    public virtual Gender Gender { get; set; } = null!;
}
