using FinalProject.DataAccess;

namespace FinalProject.DomainModels
{
    public class WarehouseDTO
    {
        public ProductCategory? CategoryCode { get; set; }
        public ProductCategory? Category { get; set; }
        public int ProductId { get; set; }
        public int RealizationPrice { get; set; }

    }
}
