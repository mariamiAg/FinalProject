using FinalProject.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.DomainModels
{
    public class CustomerDTO
    {

        public int? Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        public virtual Gender Gender { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(11)]
        public string PersonalNumber { get; set; } = null!;

        [StringLength(50)]
        public virtual ICollection<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; } = new List<CustomersPhoneNumber>();

        public string? Email { get; set; }

        public virtual City City { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<CustomerRelationship> CustomerRelationshipEndcustomers { get; set; } = new List<CustomerRelationship>();

        public virtual ICollection<CustomerRelationship> CustomerRelationshipStartCustomers { get; set; } = new List<CustomerRelationship>();

    }
}

