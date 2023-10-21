using FinalProject.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.DomainModels
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Code is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Code must be between 3 and 20 characters.")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The ExpirationDate field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;

        public virtual ProductCategory Category { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}

